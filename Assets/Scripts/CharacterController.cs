using System;
using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D Body;

    public float Speed = 1;
    public SwordController Sword;
    public JumpController Feet;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
    {
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * Speed;

        transform.localScale = new Vector3(1 * (Move.x < 0 ? -1 : 1), 1, 1);
        transform.position += Move;

	    if (Input.GetButton("Fire1"))
	        Sword.ActivateSword();
	    if (Input.GetButton("Jump") || Input.GetKey(KeyCode.Space))
            Feet.Jump();
    }
}

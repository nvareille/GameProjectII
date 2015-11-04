using System;
using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour
{
    private Rigidbody2D Body;
    private Animator Animator;

    public float Speed = 1;
    public SwordController Sword;
    public JumpController Feet;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
	{
	    float direction = Input.GetAxis("Horizontal");

        Debug.Log(direction);

	    if (direction > 0.001 || direction < -0.001)
	    {
            Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * Speed;

            transform.localScale = new Vector3((Move.x < 0 ? -2 : 2), 2, 1);
            transform.position += Move;
            Animator.SetBool("Moving", true);
	    }
	    else
	    {
	        Animator.SetBool("Moving", false);
	    }

	    if (Input.GetButton("Fire1"))
	        Sword.ActivateSword();
	    if (Input.GetButton("Jump") || Input.GetKey(KeyCode.Space))
            Feet.Jump();
    }
}

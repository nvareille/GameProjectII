using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D Body;
    public bool MayJump;
    public Vector2 JumpingForce;

	// Use this for initialization
	void Start ()
	{
	    Body = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        MayJump = true;
    }

    public void Jump()
    {
        if (MayJump)
        {
            MayJump = false;
            Body.AddForce(JumpingForce);
        }
    }
}

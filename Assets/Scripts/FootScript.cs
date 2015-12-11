using UnityEngine;
using System.Collections;

public class FootScript : MonoBehaviour {

    public bool collided;
	// Use this for initialization
	void Start () {
        collided = true;
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
            collided = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
            collided = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
            collided = true;
    }
}

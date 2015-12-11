using UnityEngine;
using System.Collections;

public class ShadowScript : MonoBehaviour {

    public bool collided = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        collided = true;
    }
}

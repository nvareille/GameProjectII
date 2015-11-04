﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	
	bool isOpen = false;
	public Texture2D openDoor;
	
	void OnTriggerStay2D(Collider2D a) {
		
		if (isOpen == false && Input.GetKeyDown ("a")) {
			
			SpriteRenderer spriterenderer = this.GetComponent<SpriteRenderer>();
			spriterenderer.sprite = Sprite.Create(openDoor, new Rect(0, 0, openDoor.width, openDoor.height), new Vector2(0.5f, 0.5f));
			isOpen = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

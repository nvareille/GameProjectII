using UnityEngine;
using System.Collections;

public class RepetableTexture : MonoBehaviour {

	SpriteRenderer sprite;

	void Awake () {
		// Get the current sprite with an unscaled size
		sprite = GetComponent<SpriteRenderer>();
		Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);
		
		// Generate a child prefab of the sprite renderer
		GameObject childPrefab = new GameObject();
		SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childPrefab.transform.position = transform.position;
		childSprite.sprite = sprite.sprite;
		
		// Loop through and spit out repeated tiles
		GameObject child;
		for (int i = 0, l = (int)Mathf.Round(sprite.bounds.size.y); i <= l; i++) {
			for (int j = 0, jl = (int)Mathf.Round(sprite.bounds.size.x); i <= jl; i++) {
				child = Instantiate(childPrefab) as GameObject;
				child.transform.position = transform.position - (new Vector3(spriteSize.x * i, spriteSize.y * j, 0));
				child.transform.parent = transform;
			}
		}
		
		// Set the parent last on the prefab to prevent transform displacement
		childPrefab.transform.parent = transform;
		
		// Disable the currently existing sprite component since its now a repeated image
		sprite.enabled = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

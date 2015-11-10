using UnityEngine;
using System.Collections;

public class SlimeMove : MonoBehaviour {
	public GameObject target;
	public float aggro = 4; /* x distance  > 4*/
	public float step = 1;/* 1 */
	public float recoil = 100; /* 200 */
	private Vector3 distance; /* between enemy and player) */
	private Vector3 normal; /* pseudo normal*/

	// Use this for initialization
	void Start () {
		if (step == 0.0f)
			step = 1.0f;
		normal = new Vector3 (1.0f, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (target != null)
		{
			distance = target.transform.position - transform.position;
			if (Mathf.Abs (distance.x) <= aggro) {
				normal = distance;
				normal.x = (normal.x == 0.0f) ? 1.0f : normal.x / Mathf.Abs (normal.x);
				normal.y = (normal.y == 0.0f) ? 0.5f : normal.y / Mathf.Abs (normal.y * 4.0f);
				normal.z = 0.0f;
				transform.position += normal * step * Time.deltaTime;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.transform.name == "Character" && col.collider != null && target != null)
		{
			distance = target.transform.position - transform.position;
			normal = distance;
			normal.x = (normal.x == 0.0f) ? 1.0f : normal.x / Mathf.Abs (normal.x);
			normal.y = (normal.y == 0.0f) ? 0.5f : normal.y / Mathf.Abs (normal.y * 4.0f);
			normal.z = 0.0f;
			

			/*SwordController swc = (SwordController) target.GetComponent(typeof(SwordController));
			if (swc != null && swc.activated)
			{

			}
			else
			{*/

			GetComponent<Rigidbody2D>().AddForce (normal * -recoil);
			CharacterStats cs = (CharacterStats) target.GetComponent(typeof(CharacterStats));
			if (cs)
				cs.TakeDamage(((CharacterStats)GetComponent(typeof(CharacterStats))).GetAttack());
		/*}*/
		}
	}
}

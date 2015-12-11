using UnityEngine;
using System.Collections;

public class BulScript : MonoBehaviour {
	
	public int dam = 1;
	public float range = 10;
	public float speed = 1;
	public int autoaim = 0; // 0 no aim, 1 Smooth aim, 2 precise aim, 3, homing aim
	
	private float currentrange;
	public Vector3 direction;
    private GameObject target;
	
	//smooth aim parameters
	public float turn = 0.5f;
	public float cheatlimit;
    private Vector3 correction;
	private Vector3 turnvector;
    private Vector3 prediction;
    private Vector3 bestposition;

	// Use this for initialization
	void Start () {
		direction = new Vector3 (0.0f, 0.0f, 0.0f);
		target = GameObject.FindGameObjectWithTag("Character");
		direction = target.transform.position - transform.position;
		direction.Normalize ();
		transform.position += direction * speed * Time.deltaTime;
		correction = new Vector3 (0.0f, 0.0f, 0.0f);
        prediction = new Vector3(0.0f, 0.0f, 0.0f);
		turnvector = new Vector3 (0.0f, 0.0f, 0.0f);
	}
	
	void preciseaim()
	{
        target = GameObject.FindGameObjectWithTag("Character");
		direction = target.transform.position - transform.position;
		direction.Normalize ();
		transform.position += direction * speed * Time.deltaTime;
	}
	
	void homingaim()
	{
	}
	
	void vectorialaim()
	{

        target = GameObject.FindGameObjectWithTag("Character");
        
        /*correction = direction * speed * Time.deltaTime;
        if (target && target.transform.position.y - transform.position.y > cheatlimit)
            correction = ((direction * speed * Time.deltaTime)) + turnveuyctor;
        else if (target && target.transform.position.y - transform.position.y < cheatlimit)
            correction = ((direction * speed * Time.deltaTime)) - turnvector;*/
        prediction =  transform.position + direction * speed * Time.deltaTime;
        bestposition = target.transform.position - prediction;
        bestposition.Normalize();
        correction = transform.position + bestposition * speed * Time.deltaTime;
        correction.Normalize();
        prediction.Normalize();

        turnvector = (correction - prediction) * turn;

        direction = (direction * speed * Time.deltaTime) + turnvector;
        direction.Normalize();
        /*if (target && target.transform.position.y - transform.position.y > cheatlimit)
			correction = ( (direction * speed * Time.deltaTime)) + turnvector;
        else if (target && target.transform.position.y - transform.position.y < cheatlimit)
			correction = ( (direction * speed * Time.deltaTime)) - turnvector;
		else
			correction = direction * speed * Time.deltaTime;*/
          
		
		transform.position += direction * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (autoaim == 1)
            vectorialaim();
		else if (autoaim == 2)
			preciseaim ();
		else
			transform.position += direction * speed * Time.deltaTime;
	}
	
	void OnTriggerEnter2D(Collider2D col) 
	{ 
		if (col.gameObject.tag == "Character")
		{
			CharacterStats cs = (CharacterStats) col.gameObject.GetComponent(typeof(CharacterStats));
			if (cs) 
				cs.TakeDamage(dam);
            GameObject.Destroy(gameObject);
		}
        else if (col.gameObject.tag != "Ennemy")
		    GameObject.Destroy(gameObject);
       
	}
}

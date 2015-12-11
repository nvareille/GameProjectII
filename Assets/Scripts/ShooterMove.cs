using UnityEngine;
using System.Collections;

public class ShooterMove : MonoBehaviour {

    private GameObject target;
    public GameObject bullet;
    public float aggro = 10; /* x distance  > 4*/
    public float range = 7; /* x distance  > 4*/
    public float danger = 4; /* x distance  > 4*/
    public float step = 1;/* 1 */
    public float recoil = 100; /* 200 */
    private Vector3 distance; /* between enemy and player) */
    private Vector3 normal; /* pseudo normal*/
    private Vector3 limit;
    private Vector3 orig;
    public float reloadtime = 3;
    private float shoottime;

    public AudioClip touchsound;
    public AudioClip shootsound;
    public AudioSource audiosource;
	// Use this for initialization
	void Start ()
    {

        target = GameObject.FindGameObjectWithTag("Character");
        limit = GetComponent<Collider2D>().bounds.size;
        shoottime = reloadtime;
	}

    bool testMove(Vector3 direction)
    {
        RaycastHit2D hit;
        Vector3 orig = transform.position;
        direction.y = 0.0f;
        
        if (direction.x > 0.0f)
            orig.x += limit.x * 0.6f;
        else
            orig.x -= limit.x * 0.6f;
        hit = Physics2D.Raycast(orig, direction, step * Time.deltaTime);
        
        if (hit.collider != null)
            return false;
        return true;
    }

    bool testAggro(Vector3 direction, Vector3 orig)
    {
        RaycastHit2D hit;
        
        direction.y = 0.0f;

        if (direction.x > 0.0f)
            orig.x += limit.x * 0.6f;
        else
            orig.x -= limit.x * 0.6f;
        hit = Physics2D.Raycast(orig, direction, Mathf.Infinity);
        if (hit.collider == null)
             return false;
        if (hit.collider.tag == "Character")
            return true;
        if (hit.collider.tag == "Ennemy" || hit.collider.tag == "Projectile")
        {
            orig = hit.collider.transform.position;
            direction.x -= hit.collider.transform.position.x - orig.x;
            return (testAggro(distance, orig));
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
        shoottime += Time.deltaTime;
        target = GameObject.FindGameObjectWithTag("Character");
        
        if (target != null)
        {
            distance = target.transform.position - transform.position;
            orig = transform.position;
            if (testAggro(distance, orig) == true)
            {
            if (Mathf.Abs(distance.x) <= aggro && Mathf.Abs(distance.x) >= range)
            {
                normal = distance;
                normal.x = (normal.x == 0.0f) ? 1.0f : normal.x / Mathf.Abs(normal.x);
                normal.y = (normal.y == 0.0f) ? 0.5f : normal.y / Mathf.Abs(normal.y * 4.0f);
                normal.z = 0.0f;

                if (testMove(normal) == true)
                transform.position += normal * step * Time.deltaTime;
            }

            else if (Mathf.Abs(distance.x) <= danger)
            {
                normal = distance;
                normal.x = (normal.x == 0.0f) ? 1.0f : normal.x / Mathf.Abs(normal.x);
                normal.y = (normal.y == 0.0f) ? 0.5f : normal.y / Mathf.Abs(normal.y * 4.0f);
                normal.z = 0.0f;
                if (testMove(-normal) == true)
                transform.position -= normal * step * Time.deltaTime;
            }

            if (Mathf.Abs(distance.x) >= danger && Mathf.Abs(distance.x) <= range && shoottime > reloadtime)
            {   
                GameObject impulsefire = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                if (target.transform.position.x < transform.position.x)
                    impulsefire.transform.position -= new Vector3(limit.x * 0.6f, 0.0f, 0.0f);
                else
                    impulsefire.transform.position += new Vector3(limit.x * 0.6f, 0.0f, 0.0f);
                shoottime = 0;
            }
            }
        }
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Character" && target != null)
        {
           distance = target.transform.position - transform.position;
            normal = distance;
            normal.x = (normal.x == 0.0f) ? 1.0f : normal.x / Mathf.Abs(normal.x);
            normal.y = (normal.y == 0.0f) ? 0.5f : normal.y / Mathf.Abs(normal.y * 4.0f);
            normal.z = 0.0f;

            
            GetComponent<Rigidbody2D>().AddForce(normal * -recoil);
            CharacterStats cs = (CharacterStats)target.GetComponent(typeof(CharacterStats));
            if (cs)
                cs.TakeDamage(((CharacterStats)GetComponent(typeof(CharacterStats))).GetAttack());
        }
    }
}

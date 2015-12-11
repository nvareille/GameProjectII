using UnityEngine;
using System.Collections;

public class WizardMove : MonoBehaviour {

    private GameObject target;
    public GameObject bullet;
    public GameObject shadow;
    public float aggro = 10; /* x distance  > 4*/
    public float step = 1;/* 1 */
    public float recoil = 100; /* 200 */
    private Vector3 distance; /* between enemy and player) */
    private Vector3 normal; /* pseudo normal*/
    private Vector3 limit;
    public AudioClip touchsound;
    public AudioClip shootsound;
    public AudioSource audiosource;

    public float reloadtime = 4;
    private float shoottime;
    public float teleportcooldown = 4;
    private float teleporttime;
    private Vector3 orig;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Character");
        limit = GetComponent<Collider2D>().bounds.size;
        shoottime = reloadtime;
        teleporttime = teleportcooldown;
	}

    IEnumerator waitforshadow()
    {
        yield return 2.0f;
    }

    bool testMove(Vector3 position)
    {
        ShadowScript myshadow = (Instantiate(shadow, position, Quaternion.Euler(0, 0, 0)) as GameObject).GetComponent<ShadowScript>();
        waitforshadow();

        if (myshadow.collided == true || Mathf.Abs(myshadow.transform.position.y - transform.position.y) >= 1.0f)
        {
            GameObject.Destroy(myshadow);
            return false;
        }
        GameObject.Destroy(myshadow);
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
	void Update () 
    {
        shoottime += Time.deltaTime;
        teleporttime += Time.deltaTime;
        target = GameObject.FindGameObjectWithTag("Character");
        if (target != null)
        {
            
            distance = target.transform.position - transform.position;

            orig = transform.position;
            if (testAggro(distance, orig) == true)
            {
                audiosource.PlayOneShot(touchsound);
                if (Mathf.Abs(distance.x) <= aggro)
                {
                    if (teleporttime > teleportcooldown)
                    {
                        distance = target.transform.position + distance;
                        if (testMove(distance) == true)
                        {
                            transform.position = distance;
                            teleporttime = 0;
                        }
                    }
                    if (shoottime > reloadtime)
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

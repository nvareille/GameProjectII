using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour
{
    private bool Activated;
    public float Lasting;
    private float LastingTemp;
    public Collider2D SwordCollider;

    void Update()
    {
        if (Activated)
        {
            LastingTemp -= Time.deltaTime;

            if (LastingTemp < 0)
            {
                DeactivateSword();
            }
        }
    }

    public void ActivateSword()
    {
        Activated = true;
        SwordCollider.enabled = true;
        LastingTemp = Lasting;
    }

    public void DeactivateSword()
    {
        Activated = false;
        SwordCollider.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.gameObject.name);
        if (c.gameObject.name == "Monster")
            Destroy(c.gameObject);
        Debug.Log("test");
    }
}

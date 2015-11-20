﻿using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour
{
    private Animator Animator;
    private bool Activated;
    public float Lasting;
    private float LastingTemp;
    public Collider2D SwordCollider;

    void Start()
    {
        Animator = transform.parent.GetComponent<Animator>();
    }

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
        Animator.SetBool("Attacking", true);
        Activated = true;
        SwordCollider.enabled = true;
        LastingTemp = Lasting;
    }

    public void DeactivateSword()
    {
        Animator.SetBool("Attacking", false);
        Activated = false;
        SwordCollider.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.gameObject.name);
        if (c.gameObject.tag == "Player")
            c.gameObject.GetComponent<CharacterStats>().TakeDamage(transform.parent.GetComponent<PlayableCharacter>().GetAttack());
        Debug.Log("test");
    }
}

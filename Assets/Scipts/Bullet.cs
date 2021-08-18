using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damge = 50;
    public float explodeRadiuos = 0f;
    public GameObject impactEffect;

    // find target;
    public void Seak(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            Hittarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);        
    }
    void Hittarget()
    {
        GameObject impactEff = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEff, 2f);
        if (explodeRadiuos > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadiuos);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }

        }
    }
    void Damage(Transform Enemy)
    {
        Enemy e = Enemy.GetComponent<Enemy>();
        e.TakeDamge(damge);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadiuos);
    }
}

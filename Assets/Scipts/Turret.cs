using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("General")]
    public float range = 12f;
    public Enemy targetEnemy;
    

    [Header("Use bullet(default)")]
    public GameObject bulletPrefab;
    public float countBullDown = 0f;
    public float bulletRate = 1f;

    [Header("Use laze (default)")]
    public bool useLaze = false;
    public LineRenderer linerender;
    public ParticleSystem impactEffect;
    public Light lightEffect;

    public int takeDamgeOverTime = 30;
    public float slowPct = .5f;


    [Header("Set up")]

    public string enemyTag = "Enemy";
    public Transform partToBase;
    public float turnSpeed = 10f;

    public Transform bulletPoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if(nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Enemy>();

            }
            else
            {
                target = null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if (useLaze)
            {
                if (linerender.enabled)
                {
                    linerender.enabled = false;
                    impactEffect.Stop();
                    lightEffect.enabled = false;
                }
                    
            }
            return;
        }
        LockOnEnemy();
        if (useLaze)
        {
            Laser();
        }
        else
        {
            if (countBullDown <= 0f)
            {
                Shoot();
                countBullDown = 1 / bulletRate;
            }
            countBullDown -= Time.deltaTime;
        }
    }
    void Laser()
    {
        targetEnemy.TakeDamge(takeDamgeOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);
        if (!linerender.enabled)
        {
            linerender.enabled = true;
            impactEffect.Play();
            lightEffect.enabled = true;
        }
           
        linerender.SetPosition(0, bulletPoint.position);
        linerender.SetPosition(1, target.position);
       
        Vector3 dir = bulletPoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
            
    }
    void LockOnEnemy()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToBase.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToBase.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seak(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyGo : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoint.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPoint();
        }

        enemy.speed = enemy.startSpeed;

    }
    void GetNextPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            Endpath();
            return;
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }
    void Endpath()
    {
        PlayerStart.Lives--;
        WaveSpawner.EnemyAlives--;
        Destroy(gameObject);
    }
}

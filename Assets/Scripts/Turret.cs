using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform[] firePoints;

    [SerializeField]
    private float timeBtwnShots = .5f,
                  startTime = 0.3f;

    [SerializeField]
    private LayerMask attackableLayers;
    private Transform target = null;

    private bool shooting = false;

    float angle;
    private void Update()
    {
        if (target == null)
            return;

        var hit = Physics2D.Raycast(transform.position, (Vector2)target.position + Vector2.up - (Vector2)transform.position, 10, attackableLayers);
        Debug.DrawRay(transform.position, 10 * ((Vector2)target.position + Vector2.up - (Vector2)transform.position), Color.blue);

        angle = Mathf.Atan2(transform.position.y - target.position.y, transform.position.x - target.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));

        if (!shooting)
        {
            shooting = true;
            InvokeRepeating("Shoot", startTime, timeBtwnShots);
        }
        if (hit.collider == null)
            target = null;
    }

    int shotCount = 0;
    private void Shoot()
    {
        if (target == null)
        {
            shooting = false;
            CancelInvoke();
        }

        var rot = transform.rotation;
        rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 180f));
        Instantiate(bullet, firePoints[++shotCount % firePoints.Length].position, rot);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (target == null && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            target = other.transform;
    }
}

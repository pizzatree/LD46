using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    private float distToShoot = 5f,
                  moveSpeed = 10f;
    [SerializeField]
    private LayerMask attackableLayers;

    private State state = State.Pursuit;
    private Transform target;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private RaycastHit2D hit;
    private Animator animator => GetComponent<Animator>();

    private Transform gun => transform.Find("Gun");

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private int numBulletsPerShot = 1,
                numShotsPerPattern = 3;
    [SerializeField]
    private float timeBtwnShots = 0.3f,
                  recovery = 0f,
                  inaccuracy = 0.075f;

    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player").transform;
        var toilet = GameObject.FindGameObjectWithTag("Toilet Guy").transform;

        var distPlayer = Vector2.Distance(transform.position + Vector3.up, player.position);
        var distToilet = Vector2.Distance(transform.position + Vector3.up, toilet.position);

        target = (distPlayer < distToilet) ? player : toilet;
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;
        hit = Physics2D.Raycast(transform.position, (Vector2)target.position - rb.position, 1000, attackableLayers);
        Debug.DrawRay(rb.position, 1000 * ((Vector2)target.position - rb.position), Color.red);

        var angle = Mathf.Atan2(gun.position.y - target.position.y, gun.position.x - target.position.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        switch (state)
        {
            case State.Pursuit:
                animator.SetBool("Running", true);
                DoPursuit();
                break;
            case State.Shoot:
                animator.SetBool("Running", false);
                DoShoot();
                break;
            default:
                break;
        }
    }

    private void DoPursuit()
    {
        if(ObstacleDistance <= distToShoot)
            state = State.Shoot;

        var nextPos = Vector2.MoveTowards(rb.position, target.position, moveSpeed * Time.fixedDeltaTime);

        rb.MovePosition(nextPos);
    }

    private void DoShoot()
    {
        if (ObstacleDistance >= 1.75f * distToShoot)
            state = State.Pursuit;

        if (!shooting)
        {
            InvokeRepeating("Shoot", 0, timeBtwnShots);
            shooting = true;
        }
    }

    bool shooting = false;
    int shotCount = 0;
    private void Shoot()
    {
        if(shotCount >= numShotsPerPattern)
        {
            shotCount = 0;
            CancelInvoke();

            if (state == State.Shoot)
                InvokeRepeating("Shoot", recovery, timeBtwnShots);
            else
                shooting = false;
        }

        for (int i = 0; i < numBulletsPerShot; ++i)
        {
            var shotRot = gun.rotation;
            shotRot.z += Quaternion.Euler( 0, 0, Random.Range(-inaccuracy, inaccuracy) ).z;

            Instantiate(bullet, gun.position, shotRot);
        }
        ++shotCount;
    }

    private float ObstacleDistance 
        => Vector2.Distance(hit.collider.transform.position, rb.position);

    private enum State
    {
        Pursuit,
        Shoot
    }
}

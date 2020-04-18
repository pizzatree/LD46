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

        switch (state)
        {
            case State.Pursuit:
                DoPursuit();
                break;
            case State.Shoot:
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
        if (ObstacleDistance >= 2 * distToShoot)
            state = State.Pursuit;
    }

    private float ObstacleDistance 
        => Vector2.Distance(hit.collider.transform.position, rb.position);

    private enum State
    {
        Pursuit,
        Shoot
    }
}

using UnityEngine;

public class Bullet : iHurt
{
    [SerializeField] private float speed = 20f;
    private Vector3 dir = Vector3.right;
    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void Start()
    {
        if (allegiance == Allegiance.Enemy)
            dir = Vector3.left;
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.collider.GetComponent<Health>();

        if (health != null && ValidHit(collision.collider.tag))
        {
            health.TakeDamage(damage);
            collision.rigidbody.MovePosition(collision.rigidbody.position + collision.contacts[0].normal * -2);
            Destroy(gameObject);
        }
    }
}

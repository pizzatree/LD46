using UnityEngine;

public class Bullet : iHurt
{
    [SerializeField] private float speed = 20f;
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.collider.GetComponent<Health>();

        if (health != null && ValidHit(collision.collider.tag))
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Bullet : iHurt
{
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}

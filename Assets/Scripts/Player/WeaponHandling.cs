using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandling : MonoBehaviour
{
    [SerializeField]
    private float maxDistanceFromPlayer = 3f;

    private bool active = false;

    public void Activate()
    {
        active = true;
    }
    public void Deactivate()
    {
        active = false;
    }

    Transform player => GameObject.FindGameObjectWithTag("Player").transform;
    
    private void Update()
    {
        if (active && GameStateManager.Instance._GameState == GameState.Shooty)
        {
            var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var offset = mousePos - ((Vector2)player.position + Vector2.up);

            // Vector2.up to compensate for player pivot being at feet
            transform.position = (Vector2)player.position + Vector2.up + Vector2.ClampMagnitude(offset, maxDistanceFromPlayer);

            var angle = Mathf.Atan2(transform.position.y - player.position.y, transform.position.x - player.position.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active)
        {
            var player = collision.GetComponent<PlayerWeapon>();

            if (player != null)
                player.SwapWeapon(GetComponent<iWeapon>());
        }
    }
}

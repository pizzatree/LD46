using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f,
                  sprintMultiplier = 2f,
                  maxSprintTime = 3f;

    private float remainingSprintTime;
    private bool ableToSprint = true;
    private Animator animator => GetComponent<Animator>();
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private void Start() => remainingSprintTime = maxSprintTime;
    private void FixedUpdate() => HandleMovement();

    private void HandleMovement()
    {
        remainingSprintTime += Time.fixedDeltaTime;
        remainingSprintTime = Mathf.Clamp(remainingSprintTime, -.1f, remainingSprintTime);

        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput.magnitude > 0.1f)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);
        
        if(Input.GetKey(KeyCode.LeftShift) && ableToSprint) // Handle Sprint
        {
            moveInput *= sprintMultiplier;
            remainingSprintTime -= 3 * Time.fixedDeltaTime;
            if (remainingSprintTime <= 0f)
            {
                ableToSprint = false;
                Invoke("ResetSprint", maxSprintTime);
            }
        }

        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void ResetSprint() => ableToSprint = true;
}
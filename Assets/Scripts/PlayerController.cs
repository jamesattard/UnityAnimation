using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float ThreePiOverFour = Mathf.PI * 3 / 4;
    private const float PiOverFour = Mathf.PI / 4;
    public float speed;
    public Animator animator;
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize(); // Keep same direction but normalize length of vector to 1

        if (movement == Vector2.zero)
        {
            animator.SetInteger("WalkState", 0);
        }
        else
        {
            float angle = Mathf.Atan2(movement.y, movement.x);
            if (angle < ThreePiOverFour && angle > PiOverFour)
            {
                animator.SetInteger("WalkState", 1);
            }
            else if (angle < PiOverFour && angle > -PiOverFour)
            {
                animator.SetInteger("WalkState", 2);
            }
            else if (angle < -PiOverFour && angle > -ThreePiOverFour)
            {
                animator.SetInteger("WalkState", 3);
            }
            else if (angle > ThreePiOverFour || angle < -ThreePiOverFour)
            {
                animator.SetInteger("WalkState", 4);
            }
        }

        rb2D.velocity = movement * speed * Time.deltaTime;

    }
}

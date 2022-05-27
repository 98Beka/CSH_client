using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    [SerializeField] Joystick joystick;
    float horizontal; 
    float vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Jump");
    }

    void FixedUpdate()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 1.0f * horizontal * Time.deltaTime;
        position.y = position.y + 1.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}

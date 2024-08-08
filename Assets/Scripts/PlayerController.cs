using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    [SerializeField] private Vector3 jumpVelocity;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private CharacterController controller;

    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private bool grounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
    
        if (grounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical);

        if(moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }

        moveDirection *= speed;

        if(moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
        }

        controller.Move(moveDirection * Time.deltaTime);

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        jumpVelocity.y += gravity * Time.deltaTime;
        controller.Move(jumpVelocity * Time.deltaTime);
    }
}

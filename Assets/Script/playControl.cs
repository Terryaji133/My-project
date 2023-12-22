using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class playControl : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed;

    public float jumpSpeed;

    private float horizontalMove, verticalMove;

    private Vector3 dir;

    public float gravity;

    private Vector3 velocity;

    public Transform groundCheck;

    public float checkRadius;

    public LayerMask groundLayer;

    public bool isGrounded;

    Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere (groundCheck.position, checkRadius, groundLayer) ;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -11f;
        }


        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir*Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpSpeed;
        }

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        animator.SetFloat("speed", Mathf.Abs(dir.magnitude));
    }
}

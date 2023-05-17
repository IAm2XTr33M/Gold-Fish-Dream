using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float JumpForce = 6f;
    public float gravityScale = 6f;

    float horizontalMove;
    float verticalMove;

    public bool isGrounded;
    public bool canJump = true;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        MyInput();

        if(Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            Jump();
        }
        else
        {
            rb.AddForce(transform.up * -gravityScale, ForceMode.Acceleration);
        }
    }

    void Jump()
    {
        canJump = false;
        transform.position += new Vector3(0, 0.2f, 0);
        rb.AddForce(transform.up * JumpForce/5, ForceMode.Impulse);
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        StartCoroutine(delay());


        IEnumerator delay()
        {
            yield return new WaitForSeconds(0.5f);
            canJump = true;
        }
    }

    void MyInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
    }
}

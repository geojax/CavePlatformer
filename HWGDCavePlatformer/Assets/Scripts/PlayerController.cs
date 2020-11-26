using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed = 5;

    [SerializeField] float jumpForce = 5;
    bool canJump = true;
    Ray jumpRay;

    LayerMask platformLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        platformLayer = LayerMask.GetMask("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb2d.velocity.y);
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && canJump)
        {
            Jump();
        }
        Debug.DrawRay(transform.position, Vector3.down * 10, Color.red);

    }

    private void FixedUpdate()
    {
        jumpRay.origin = transform.position; // What's wrong with this?
        jumpRay.direction = Vector3.down;
        if (Physics.Raycast(jumpRay, 10f, platformLayer))
        {
            canJump = true;
            Debug.Log("I can jump!");
        }
    }

    void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        canJump = false;
    }
}

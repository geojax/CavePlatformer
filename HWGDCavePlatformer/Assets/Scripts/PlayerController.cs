using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed = 5;

    [SerializeField] float jumpForce = 5;
    bool canJump = true;
    public float rayDistance = 0.7f;

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

        canJump = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, platformLayer);

        if ((Input.GetKeyUp("w") || Input.GetKeyUp("up")) && rb2d.velocity.y > 0f)
        {
            //rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - 3f);
            rb2d.AddForce(Vector2.down * 2, ForceMode2D.Impulse);
        }
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        canJump = false;
    }
}

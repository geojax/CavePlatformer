using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb2d.velocity.y);
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}

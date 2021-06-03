using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody2D rb2d;
    public float jumpForce = 10f;
    public LayerMask groundLayerMask;
    private bool isGrounded;
    public float raycastScanDistance = 0.7f;
    public GameObject bulletPrefab;
    public Transform bulletPrefabLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastScanDistance, groundLayerMask); ;
        if (hit.collider != null && hit.distance > 0.5f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jump ability
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        // Horizontal movement
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

    }

    private void FixedUpdate()
    {
        
    }
}

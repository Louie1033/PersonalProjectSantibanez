using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10;
    public float gravityModifier = 5;
    public float jumpForce = 50;

    public int jumpCount = 0;
    
    private Rigidbody playerRb;
    private Animator playerAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetAxis("Horizontal") != 0 )
        {
            
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
            playerAnim.SetFloat("Speed_f", .6f);
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce);
            jumpCount++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}

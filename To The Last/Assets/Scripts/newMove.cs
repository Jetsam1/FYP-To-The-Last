using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMove : MonoBehaviour
{
    public Rigidbody rb;
    public float sensitivity;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded;
    private bool isWallRunning;
    [SerializeField]
    private bool isSlowed;
    private bool isSliding;
    public float slowFac;
    [SerializeField]
    private float baseSlideVal;
    private float slideForce;
    private float slideTime = 3.5f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        RaycastHit raycast;

        if (Physics.Raycast(transform.position, Vector3.down, out raycast, 1.25f))
        {
            isGrounded = true;
          //  Debug.Log("ray hit floor");
        }
        if (!Physics.Raycast(transform.position, Vector3.down, out raycast, 1.25f))
        {
            isGrounded = false;
        }
        if (Physics.Raycast(transform.position, Vector3.left, out raycast, 1.25f))// && Input.GetButtonDown("Left"))
        {
           // isWallRunning = true;
          ///  Debug.Log("ray left");
        }
        if (Physics.Raycast(transform.position, Vector3.right, out raycast, 1.25f))// && Input.GetButtonDown("Right"))
        {
           // isWallRunning = true;
          //  Debug.Log("ray right");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left ctrl")) isSliding = true;
        if (Input.GetKeyUp("left ctrl")) isSliding = false;
        if (Input.GetKeyDown("left shift")) isSlowed = true;
        if (Input.GetKeyUp("left shift")) isSlowed = false;
        if(isSlowed)
        {
            rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed* slowFac) + (Input.GetAxis("Horizontal") * moveSpeed * transform.right * slowFac));
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce * slowFac);
            }
        }
        else if(isWallRunning)
        {
            rb.useGravity = false;
            rb.MovePosition(transform.position + (transform.forward * moveSpeed));
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.left, out hit, 1.25f))
                {
                    rb.AddForce((transform.right * jumpForce) + (transform.up * jumpForce * 0.5f));
                    rb.useGravity = true;

                }
                else if (Physics.Raycast(transform.position, Vector3.right, out hit, 1.25f))
                {
                    rb.AddForce((-transform.right * jumpForce) + (transform.up * jumpForce * 0.5f));
                    rb.useGravity = true;
                }
                else
                {
                    rb.useGravity = true;
                    isWallRunning = false;
                }
            }
        }
        if (isSliding)
        {

            //rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (Input.GetAxis("Horizontal") * moveSpeed * transform.right));
            rb.AddForce(transform.forward * slideForce);
            
              slideForce = slideForce * -Mathf.Exp(2);
              Debug.Log(slideForce);
 
        }
        else
        {
            rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (Input.GetAxis("Horizontal") * moveSpeed * transform.right));
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }
            slideForce = baseSlideVal;
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0)));
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.tag == "Wall")
        {
            rb.useGravity = false;
            isWallRunning = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "Wall")
        {
            rb.useGravity = true;
            isWallRunning = false;
        }
    }
}




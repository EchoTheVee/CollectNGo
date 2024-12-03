using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed;
    public Rigidbody rb;
    public float jumpHeight;
    public bool grounded;
    public float canJump;
    public float mass;
    public float sprinting;
    public float canGroundSlam;
    public float gravity;
    public float dashSpeed;
    private float playerHeight;
    public GameObject playerCam;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = playerCam.transform.rotation;

        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        //rb.AddRelativeForce(Vector3.right * moveSpeed * horizontalInput, ForceMode.Force);
        //transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);

        //Vertical Movement
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * moveSpeed * verticalInput * sprinting, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight * canJump, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(Vector3.down * gravity * canGroundSlam, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Debug.Log("RMB");
            rb.AddRelativeForce(Vector3.forward * dashSpeed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerHeight = GetComponent<CapsuleCollider>().height = 1;

            rb.AddRelativeForce(Vector3.forward * dashSpeed, ForceMode.Impulse);
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerHeight = GetComponent<CapsuleCollider>().height = 2;
        }

        if (grounded == true)
        {
            canJump = 1;
            canGroundSlam = 0;
        }

        else if (grounded == false)
        {
            canJump = 0;
            canGroundSlam = 1;
        }

        if (grounded == false)
        {
            rb.AddForce(Vector3.down * mass, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = 1.5f;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = 1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Joystick joystickmove;
    public Rigidbody rb;
    public float forceJump = 5f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        rb.velocity = new Vector3(joystickmove.Horizontal * speed + Input.GetAxis("Horizontal"), rb.velocity.y, joystickmove.Vertical * speed + Input.GetAxis("Vertical"));
    }


   public void JumpBt()
    {
        rb.velocity += Vector3.up * forceJump;
    }

}

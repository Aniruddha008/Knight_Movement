using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float rotation = 0;
    [SerializeField] float rotationSpeed = 80f;
    [SerializeField] float gravity = 8f;
    
    
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
               if(Input.GetKey(KeyCode.W))
       {
           moveDirection = new Vector3(0, 0, 1);
           moveDirection *= speed;
           moveDirection = transform.TransformDirection(moveDirection);
           anim.SetBool("walk", true);

           if (Input.GetKey(KeyCode.R))
           {
           moveDirection = new Vector3(0, 0, 1);
           moveDirection *= speed*1.5f;
           moveDirection = transform.TransformDirection(moveDirection);
           anim.SetBool("run", true);
           }
        
        if(Input.GetKeyUp(KeyCode.R))
       {
           moveDirection = Vector3.zero;
           anim.SetBool("run", false);
       }

       }

       if(Input.GetKeyUp(KeyCode.W))
       {
           moveDirection = Vector3.zero;
           anim.SetBool("walk", false);
       }
       
       rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
       transform.eulerAngles = new Vector3(0, rotation, 0);

       moveDirection.y =- gravity*Time.deltaTime;
       controller.Move(moveDirection * Time.deltaTime);
    }
}

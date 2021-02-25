using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    CharacterController controller;
    CollideCheck collideCheck;

    
    [Header("Movement settings")]
    public float speed ;
    public float gravity;
    public float jumpHeight;

    [Space]
    public Vector3 velocity;
    public bool IsGrounded;


    private void Start() {
        controller = GetComponent<CharacterController>();
        collideCheck = GetComponent<CollideCheck>();
    }

    private void Update() {
        if (collideCheck.InContact == true && velocity.y < 0) {
            velocity.y = -2f;
        }
    
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    
        Vector3 move = transform.right * x + transform.forward * z;
    
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
    
        if (Input.GetButtonDown("Jump") && collideCheck.InContact) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    
        controller.Move(velocity * Time.deltaTime);
    }


   

}

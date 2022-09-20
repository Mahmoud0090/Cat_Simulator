using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTouchToMove : MonoBehaviour
{
    Touch touch;
    Vector2 initPos;
    Vector2 direction;
    public CharacterController characterController;
    Vector3 moveDirection;
    public float speed = 5f;
    bool canMove = false;
    public float gravity = 10f;
    public float jumpForce = 3f;
    public float stopForce = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            canMove = true;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                direction = touch.deltaPosition;
            }
            if (characterController.isGrounded)
            {
                moveDirection = new Vector3(
                    touch.position.x - initPos.x,
                    0,
                    touch.position.y - initPos.y
                );
                Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
                transform.rotation = targetRotation;

                moveDirection = moveDirection * speed;
            }
        }
        else
        {
            canMove = false;
            moveDirection = Vector3.Lerp(moveDirection , Vector3.zero , stopForce * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveDirection.y += jumpForce;
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

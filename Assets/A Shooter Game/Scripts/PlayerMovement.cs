using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        movement = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        transform.Translate(movement.normalized * Time.deltaTime * speed, Space.World);
    }
}

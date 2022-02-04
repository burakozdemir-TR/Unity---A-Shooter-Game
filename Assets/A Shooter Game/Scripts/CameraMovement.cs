using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity;
    public Transform player;
    private float xRotation = 0;
    private void Start()
    {
        transform.localRotation = Quaternion.identity;
    }
    private void Update()
    {
        Look();
    }
    private void Look()
    {
        var m = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        m *= sensitivity * Time.deltaTime;

        xRotation -= m.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(Vector3.up, m.x);
    }
}

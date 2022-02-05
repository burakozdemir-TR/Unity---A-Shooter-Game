using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    private Rigidbody rb;
    public Transform firePoint;
    BulletPooler bulletPooler;
    private void Start()
    {
        bulletPooler = BulletPooler.Instance;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Movement();
        Shoot();
    }
    private void Movement()
    {
        movement = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        transform.Translate(movement.normalized * Time.deltaTime * speed, Space.World);
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = bulletPooler.GetFromPool<Bullet>("ShotgunShells");
            bullet.transform.position = firePoint.position;
            bullet.transform.forward = firePoint.forward;
        }
    }
}

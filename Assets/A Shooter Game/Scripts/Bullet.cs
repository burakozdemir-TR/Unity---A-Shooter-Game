using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private Rigidbody rb;
    public Vector2 horizontalSpread;
    public Vector2 verticalSpread;
    public float bulletSpeed;
    public void Configure(Transform shootFrom)
    {
        var shootRotation = 
        shootFrom.rotation.eulerAngles 
        + Vector3.right * Random.Range(horizontalSpread.x, horizontalSpread.y)
        + Vector3.up * Random.Range(verticalSpread.x, verticalSpread.y);

        transform.position = shootFrom.position;
        transform.rotation = Quaternion.Euler(shootRotation);

        rb.velocity = transform.forward * bulletSpeed;
    }
    public bool IsAvailable { get; set; }   
    public void OnObjectSpawn()
    {
        gameObject.SetActive(true);
        IsAvailable = false;
        Invoke("Pool", 2f);
    }

    public void Pool()
    {
        gameObject.SetActive(false);
        IsAvailable = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private Rigidbody rb;

    public bool IsAvailable { get; set; }   
    public void OnObjectSpawn()
    {
        gameObject.SetActive(true);
        IsAvailable = false;

        Vector3 force = new Vector3(10,0,0);
        rb.velocity = force;
        Invoke("Pool", 2f);
    }

    public void Pool()
    {
        gameObject.SetActive(false);
        IsAvailable = true;
    }
}

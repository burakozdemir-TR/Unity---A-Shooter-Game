using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    BulletPooler bulletPooler;
    public Text shootCountText;
    void Start()
    {
        bulletPooler = BulletPooler.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    { 
        var randomBulletCount = Random.Range(10, 21);
        shootCountText.text = randomBulletCount.ToString();
        for (int i = 0; i < randomBulletCount; i++)
        {
            var bullet = bulletPooler.GetFromPool<Bullet>("ShotgunShells");
            bullet.Configure(firePoint);
        }
    }
}

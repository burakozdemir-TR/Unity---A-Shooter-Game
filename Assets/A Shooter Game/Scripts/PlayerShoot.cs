using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [HideInInspector]
    public int shootCount = 0;
    public Transform firePoint;
    BulletPooler bulletPooler;
    private bool canShootable = false;
    void Start()
    {
        bulletPooler = BulletPooler.Instance;
        Actions.mainMenuFadeOut += ToggleShootable;
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
        if (!canShootable)
            return;
        var randomBulletCount = Random.Range(10, 21);
        shootCount = randomBulletCount;
        Actions.shootCountUpdate?.Invoke(this);
        for (int i = 0; i < randomBulletCount; i++)
        {
            var bullet = bulletPooler.GetFromPool<Bullet>("ShotgunShells");
            bullet.Configure(firePoint);
        }
    }
    private void ToggleShootable()
    {
        canShootable = !canShootable;
    }
}

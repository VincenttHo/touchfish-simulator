using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPos;

    public float shootIntervalTime;
    private float shootTimer;

    protected void Start()
    {
        shootTimer = shootIntervalTime;
    }

    protected void Update()
    {
        shootTimer += Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        if (shootTimer >= shootIntervalTime)
        {
            InitBullet();
            shootTimer = 0;
        }
    }

    protected virtual void InitBullet()
    {
        var newBullet = GameObject.Instantiate(bullet);
        newBullet.transform.position = shootPos.position;
        newBullet.transform.rotation = shootPos.rotation;
    }

}

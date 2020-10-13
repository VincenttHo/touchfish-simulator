using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    private Rigidbody rigi;
    public int atk;

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
        rigi.velocity = rigi.velocity + transform.forward * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

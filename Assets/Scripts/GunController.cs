using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPos;

    private PreFrameRaycast raycast;

    private void Start()
    {
        raycast = GetComponent<PreFrameRaycast>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var newBullet = GameObject.Instantiate(bullet);
            newBullet.transform.position = shootPos.position;
            RaycastHit hitInfo = raycast.GetHitInfo();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigi;

    [Header("速度")]
    public float speed;
    private Vector3 velocity;
    public Camera mainCamera;
    public GameObject bullet;
    public Transform shootPos;
    private Vector3 target;
    public float shootIntervalTime;
    private float shootTimer;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        shootTimer = shootIntervalTime;
    }

    void Update()
    {
        velocity = Vector3.zero;
        float x = 0;
        float z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            z = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = speed;
        }
        velocity = new Vector3(x, 0, z);
        LookMouse();
        if(Input.GetMouseButton(0))
        {
            if(shootTimer >= shootIntervalTime)
            {
                var newBullet = GameObject.Instantiate(bullet);
                newBullet.transform.position = shootPos.position;
                //newBullet.transform.LookAt(target);
                newBullet.transform.rotation = shootPos.rotation;
                shootTimer = 0;
            }
        }
        shootTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Movement(velocity);
    }

    void Movement(Vector3 velocity)
    {
        rigi.velocity = velocity;
    }

    void LookMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 200))
        {
            target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}

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
    public bool canHurt;
    private MeshRenderer meshRenderer;

    [Header("无敌时间")]
    public float invincibleDuration;
    /** 无敌计时器 */
    private float invincibleTimer;

    [Header("受伤闪烁间隔")]
    public float blinkInterval;
    private float blinkTimer;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
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
        


        if (!canHurt)
        {
            Blink();
            if (invincibleTimer <= invincibleDuration)
            {
                invincibleTimer += Time.deltaTime;
            }
            else
            {
                invincibleTimer = 0f;
                canHurt = true;
            }
        }
        else
        {
            meshRenderer.enabled = true;
        }

    }

    private void Blink()
    {
        // 受伤闪烁
        if (blinkTimer > blinkInterval)
        {
            if (meshRenderer.enabled)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = true;
            }
            blinkTimer = 0f;
        }
        else
        {
            blinkTimer += Time.deltaTime;
        }

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

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && canHurt)
        {
            HpManager.instance.Hurt();
            canHurt = false;
        }
    }

}

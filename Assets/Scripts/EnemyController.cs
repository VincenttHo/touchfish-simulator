using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp;
    public float speed;
    private Rigidbody rigi;
    private GameObject player;
    private MeshRenderer meshRenderer;

    enum HpColor
    {
        RED = 3,
        ORANGE = 2,
        YELLOW = 1
    }

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor();
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        rigi.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            int atk = other.GetComponent<BulletController>().atk;
            hp -= atk;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                ChangeColor();
            }
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            int atk = other.gameObject.GetComponent<BulletController>().atk;
            hp -= atk;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                ChangeColor();
            }
            Destroy(other.gameObject);
        }
    }

    void ChangeColor()
    {
        if(hp == (int)HpColor.RED) 
        {
            meshRenderer.material.color = Color.red;
        }
        else if (hp == (int)HpColor.ORANGE)
        {
            meshRenderer.material.color = new Color(0.85f, 0.35f, 0, 1);
        }
        else if (hp == (int)HpColor.YELLOW)
        {
            meshRenderer.material.color = Color.yellow;
        }
    }
}

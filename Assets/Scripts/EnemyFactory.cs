using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{

    public float leftMin;
    public float leftMax;

    public float rightMin;
    public float rightMax;

    public float upMin;
    public float upMax;

    public float downMin;
    public float downMax;

    public float initDuractionTime;
    private float initTimer;

    public GameObject enemy;

    private void Update()
    {
        if(initTimer >= initDuractionTime)
        {
            initTimer = 0;
            int dir = Random.Range(1, 5);
            float z = 0;
            float x = 0;
            if (dir == 1)
            {
                z = Random.Range(upMin, upMax);
                x = Random.Range(leftMin, rightMax);
            }
            if (dir == 2)
            {
                z = Random.Range(downMin, downMax);
                x = Random.Range(leftMin, rightMax);
            }
            if (dir == 3)
            {
                z = Random.Range(leftMin, leftMax);
                x = Random.Range(downMin, upMax);
            }
            if (dir == 4)
            {
                z = Random.Range(rightMin, rightMax);
                x = Random.Range(downMin, upMax);
            }
            var newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(x, newEnemy.transform.position.y, z);
        }
        else
        {
            initTimer += Time.deltaTime;
        }
    }

}

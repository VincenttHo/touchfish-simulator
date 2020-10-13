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

    private EnemyGenrateConfig[] enemyGenrateConfigs;
    private EnemyGenrateConfig currentConfig;

    public GameObject normalEnemy;
    public GameObject specialEnemy;

    private void Start()
    {
        enemyGenrateConfigs = GetComponentsInChildren<EnemyGenrateConfig>();
        GetLevelConfig();
    }

    private void Update()
    {
        InitEnemy();
    }

    private void LateUpdate()
    {
        LevelUpListner();
    }

    void InitEnemy()
    {
        if (initTimer >= currentConfig.initDuractionTime)
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
            GameObject enemy = GetEnemy();
            if (enemy != null)
            {
                var newEnemy = Instantiate(enemy);
                newEnemy.transform.position = new Vector3(x, newEnemy.transform.position.y, z);
            }
        }
        else
        {
            initTimer += Time.deltaTime;
        }
    }

    GameObject GetEnemy()
    {
        int enemyNo = Random.Range(1, 3);
        if(currentConfig.totalEnemy <= 0)
        {
            return null;
        }
        if(enemyNo == 1)
        {
            if(currentConfig.normalEnemy > 0)
            {
                currentConfig.normalEnemy--;
                return normalEnemy;
            }
            else
            {
                return GetEnemy();
            }
        }
        else if(enemyNo == 2)
        {
            if (currentConfig.specialEnemy > 0)
            {
                currentConfig.specialEnemy--;
                return specialEnemy;
            }
            else
            {
                return GetEnemy();
            }
        }
        else
        {
            return null;
        }
    }

    void LevelUpListner()
    {
        if(currentConfig.totalEnemy <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies == null || enemies.Length <= 0)
            {
                LevelManager.instance.LevelUp();
                GetLevelConfig();
            }
        }
    }

    void GetLevelConfig()
    {
        for(int n = 0; n < enemyGenrateConfigs.Length; n++)
        {
            if(enemyGenrateConfigs[n].level == LevelManager.instance.currentLevel)
            {
                currentConfig = enemyGenrateConfigs[n];
                break;
            }
        }
    }

}

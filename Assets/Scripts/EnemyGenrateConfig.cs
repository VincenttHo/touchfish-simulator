using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenrateConfig : MonoBehaviour
{

    public int level;

    public float initDuractionTime;

    public int normalEnemy;

    public int specialEnemy;

    public int totalEnemy;

    private void Update()
    {
        totalEnemy = normalEnemy + specialEnemy;
    }

}

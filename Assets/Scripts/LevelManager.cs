using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int currentLevel = 1;

    public static LevelManager instance;

    private Text levelText;

    private void Start()
    {
        instance = this;
        levelText = GetComponent<Text>();
    }

    private void Update()
    {
        levelText.text = currentLevel + "";
    }

    public void LevelUp()
    {
        currentLevel++;
    }

}

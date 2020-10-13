using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{

    private Text text;

    public static MoneyController instance;

    private int currentMoney;

    void Start()
    {
        instance = this;
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = currentMoney + "";
    }

    public void AddMoney(int money)
    {
        currentMoney += money;
    }
}

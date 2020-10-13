using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{

    public int maxHp;
    public int currentHp;
    public GameObject heart;
    public RectTransform nextPos;
    public float intervalX;

    private Stack<GameObject> heartStack;
    public static HpManager instance;
    private GameObject player;

    void Start()
    {
        instance = this;
        heartStack = new Stack<GameObject>();
        Recover(maxHp);

        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Recover(1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MaxUp();
        }
    }

    public void Hurt()
    {
        if(currentHp > 0)
        {
            currentHp--;
            GameObject deleteHeart = heartStack.Pop();
            Destroy(deleteHeart);
            nextPos.position = nextPos.position + new Vector3(intervalX, 0, 0);
            if (currentHp <= 0)
            {
                Destroy(player);
                UIManager.instance.GameOver();
            }
        }
    }

    void InitHeart()
    {
        var newHeart = Instantiate(heart);
        newHeart.transform.position = nextPos.position;
        newHeart.transform.parent = transform;

        nextPos.position = nextPos.position - new Vector3(intervalX, 0, 0);
        heartStack.Push(newHeart);
        currentHp++;
    }

    public void Recover(int hp)
    {
        for(int n = 0; n < hp; n++)
        {
            if (currentHp == maxHp) break;
            InitHeart();
        }
    }

    public void MaxUp()
    {
        maxHp++;
        InitHeart();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int _receivePoint = 100000;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        //_enemyHP = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamemanager.GetComponent<IGetValue>().GetPoint(_receivePoint);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour, IDamage
{

    [Header("Enemy��HP"), SerializeField] public int _enemyHP = 1;
    [Header("Enemy�̍U���l"), SerializeField] public int _damageValue = 2;
    [Header("Enemy�ۗ̕L�|�C���g"), SerializeField] public int _receivePoint = 2;

    GameObject gamemanager;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        //_enemyHP = 1;
    }

    private void Update()
    {
        if (_enemyHP <= 0)
        {
            gamemanager.GetComponent<IGetValue>().GetPoint(_receivePoint);
            Destroy(gameObject);
            //GameManager._score += 10;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<IDamage>().ReceiveDamage(_damageValue);
        }
    }

    public void ReceiveDamage(int damage)
    {
        _enemyHP -= damage;
    }
}

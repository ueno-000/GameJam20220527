using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallMove : MonoBehaviour,IDamage
{
    private GameObject po;
    //private Vector3 playerPosition;
    private Vector3 enemyPosition;

    private Collider2D expBomb;

    [Header("EnemyÇÃHP"), SerializeField] public int _enemyHP = 1;
    [Header("EnemyÇÃçUåÇíl"), SerializeField] public int _damageValue = 2;

    void Start()
    {
        po = GameObject.FindWithTag("Player");
        expBomb = GetComponent<BoxCollider2D>();
        expBomb.enabled = false;
        //playerPosition = po.transform.position;
        enemyPosition = transform.position;

        //_enemyHP = 1;
    }

    void Update()
    {
        //playerPosition = po.transform.position;
        enemyPosition = transform.position;

            enemyPosition.y = enemyPosition.y - 0.01f;


        transform.position = enemyPosition;

        if (_enemyHP == 0)
        {
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
        else if (col.gameObject.tag == "Ground")
        {
            expBomb.enabled = true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<IDamage>().ReceiveDamage(_damageValue);
        }
    }

    public void ReceiveDamage(int damage)
    {
        _enemyHP -= damage;
    }

}

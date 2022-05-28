using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallMove : MonoBehaviour,IDamage
{
    private GameObject po;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;

    [Header("Enemy‚ÌHP"), SerializeField] public int _enemyHP = 1;
    [Header("Enemy‚ÌUŒ‚’l"), SerializeField] public int _damageValue = 2;

    void Start()
    {
        po = GameObject.FindWithTag("Player");
        playerPosition = po.transform.position;
        enemyPosition = transform.position;

        //_enemyHP = 1;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = po.transform.position;
        enemyPosition = transform.position;

        if (playerPosition.y > enemyPosition.y)
        {
            enemyPosition.y = enemyPosition.y + 0.01f;
        }

        else if (playerPosition.y < enemyPosition.y)
        {
            enemyPosition.y = enemyPosition.y - 0.01f;
        }


        transform.position = enemyPosition;

        if (_enemyHP == 0)
        {
            Destroy(gameObject);
            GameManager._score += 10;
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
            Destroy(gameObject);
        }
    }
    public void ReceiveDamage(int damage)
    {
        _enemyHP -= damage;
    }
}

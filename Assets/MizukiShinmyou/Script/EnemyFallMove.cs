using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallMove : MonoBehaviour
{
    private GameObject po;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;

    [SerializeField] public int _enemyHP = 1;

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
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _enemyHP--;
        }
        else
        {
            _enemyHP--;
        }
    }
}

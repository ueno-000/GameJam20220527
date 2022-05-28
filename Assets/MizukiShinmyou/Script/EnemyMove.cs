using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour,IDamage
{
    // Start is called before the first frame update
    private GameObject po;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;

    [Header("Enemy��HP"),SerializeField] public int _enemyHP = 1;
    [Header("Enemy�̍U���l"), SerializeField] public int _damageValue = 2;
    
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

        if (playerPosition.x > enemyPosition.x)
        {
            enemyPosition.x = enemyPosition.x + 0.01f;
        }

        else if(playerPosition.x < enemyPosition.x)
        {
            enemyPosition.x = enemyPosition.x - 0.01f;
        }

        transform.position = enemyPosition;

        if (_enemyHP <= 0)
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
    }

    public void ReceiveDamage(int damage)
    {
        _enemyHP -= damage;
    }
}

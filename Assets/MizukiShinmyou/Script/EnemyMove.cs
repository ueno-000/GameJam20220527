using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour,IDamage
{
    // Start is called before the first frame update
    private GameObject po;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;

    [Header("EnemyのHP"),SerializeField] public int _enemyHP = 1;
    [Header("Enemyの攻撃値"), SerializeField] public int _damageValue = 2;
    [Header("Enemyの保有ポイント"), SerializeField] public int _receivePoint = 2;

    private Animator animator;
    string state;
    string oldstate;

    GameObject gamemanager;
    void Start()
    {
        po = GameObject.FindWithTag("Player");
        gamemanager = GameObject.Find("ScoreManager");
        playerPosition = po.transform.position;
        enemyPosition = transform.position;
        animator = GetComponent<Animator>();
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
            gamemanager.GetComponent<IGetValue>().GetPoint(_receivePoint);
            Destroy(gameObject);
            //GameManager._score += 10;
        }

        /*if (Input.GetKeyDown(KeyCode.O))
        {
            state = "DAMAGE";
            Debug.Log("Damage");
        }*///デバック用

        ChangeAnimation();
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
        state = "DAMAGE";
        _enemyHP -= damage;
    }
    
    void ChangeAnimation()
    {
        if(oldstate != state)
        {
            switch (state)
            {
                case "DAMAGE":
                    animator.SetBool("Idle", false);
                    animator.SetBool("Damage",true); ;
                    break;
                default:
                    animator.SetBool("Idle", false);
                    animator.SetBool("Damage", false);
                    break;
            }
            oldstate = state;
        }
    }
}

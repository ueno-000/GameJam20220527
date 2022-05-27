using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] public float _speed = 5f; //SerializeField...unity内で設定(数値なら数値)を変えられる
    [SerializeField] float _jumpPower = 10f;

    bool _isGround; //bool...真偽(true or false)の判定

    private float _h;
    private float speed;
   
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        　　　　　　　　  //↑↓InputManagerで"Horizontal","Jump"が作られているから(GetKeyCode"Space")といったことをしなくていい
        if (Input.GetButtonDown("Jump") && _isGround == true)
            //"Jump"のキーが押され、かつ、_isGroundがtrueの時に実行される
        {
            _rb.AddForce(Vector2.up*_jumpPower,ForceMode2D.Impulse); //Vector2...2次元(Vector2.up...y軸方向に力が加えられる)
             //↑ここまででジャンプはできる
             //着地以降の操作
           _isGround = false; //_isGroundを「true → false」に変更
        }
    }
    void FixedUpdate()
    {
        //待機
        if (_h == 0)
        {
            speed = 0;
        }
        //右に移動
        else if (_h > 0)
        {
            speed = _speed;
        }
        //左に移動
        else if (_h < 0)
        {
            speed = _speed * -1;
        }
        // キャラクターを移動 Vextor2(x軸スピード、y軸スピード(元のまま))
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }

    //接地したらジャンプできる(ジャンプ後に_isGroundをfalse→trueに戻し、
    //　　　　　　　　　　　　 接地している時にジャンプできるようにする)  24～31のif文に戻る
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
}

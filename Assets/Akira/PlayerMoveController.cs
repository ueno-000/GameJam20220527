using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    [SerializeField] float _jumpPower = 10f;

    bool _isGround;

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

        if (Input.GetButtonDown("Jump") && _isGround == true)
        {
            _rb.AddForce(Vector2.up*_jumpPower,ForceMode2D.Impulse);
            _isGround = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
}

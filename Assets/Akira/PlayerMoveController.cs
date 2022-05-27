using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] public float _speed = 5f; //SerializeField...unity���Őݒ�(���l�Ȃ琔�l)��ς�����
    [SerializeField] float _jumpPower = 10f;

    bool _isGround; //bool...�^�U(true or false)�̔���

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
        �@�@�@�@�@�@�@�@  //����InputManager��"Horizontal","Jump"������Ă��邩��(GetKeyCode"Space")�Ƃ��������Ƃ����Ȃ��Ă���
        if (Input.GetButtonDown("Jump") && _isGround == true)
            //"Jump"�̃L�[��������A���A_isGround��true�̎��Ɏ��s�����
        {
            _rb.AddForce(Vector2.up*_jumpPower,ForceMode2D.Impulse); //Vector2...2����(Vector2.up...y�������ɗ͂���������)
             //�������܂łŃW�����v�͂ł���
             //���n�ȍ~�̑���
           _isGround = false; //_isGround���utrue �� false�v�ɕύX
        }
    }
    void FixedUpdate()
    {
        //�ҋ@
        if (_h == 0)
        {
            speed = 0;
        }
        //�E�Ɉړ�
        else if (_h > 0)
        {
            speed = _speed;
        }
        //���Ɉړ�
        else if (_h < 0)
        {
            speed = _speed * -1;
        }
        // �L�����N�^�[���ړ� Vextor2(x���X�s�[�h�Ay���X�s�[�h(���̂܂�))
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }

    //�ڒn������W�����v�ł���(�W�����v���_isGround��false��true�ɖ߂��A
    //�@�@�@�@�@�@�@�@�@�@�@�@ �ڒn���Ă��鎞�ɃW�����v�ł���悤�ɂ���)  24�`31��if���ɖ߂�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
}

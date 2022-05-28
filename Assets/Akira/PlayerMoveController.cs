using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    /// <summary>
    /// Player��MoveValue
    /// </summary>
    [SerializeField] public float _speed = 5f; //SerializeField...unity���Őݒ�(���l�Ȃ琔�l)��ς�����
    [SerializeField] float _jumpPower = 10f;

    /// <summary> �e�e(bullet) </summary>
    [SerializeField] GameObject _bullet;
    /// <summary> �e��(Muzzle) </summary>
    [SerializeField] Transform _muzzle;
    
    /// <summary>�ڒn����</summary>
    bool _isGround; //bool...�^�U(true or false)�̔���

    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
    [SerializeField] bool _flipX = false;
    /// <summary>���]����</summary>
    public bool isReturn;

    /// <summary> ���������̓��͒l</summary>
    float _scaleX;
    private float _h;
    private float speed;

    /// <summary>SE</summary>
    [SerializeField] AudioSource _sound1;

    Animator _anim = default;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
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


        if (Input.GetButtonDown("Fire1"))
        {
            var go  = Instantiate(_bullet,_muzzle.position,this.transform.rotation);
            _sound1.PlayOneShot(_sound1.clip);

            if (this.transform.localScale.x < 0)
            {
                go.transform.Rotate(Vector3.forward,180f);
            }
        }

        if (_flipX)
        {
            FlipX(_h);
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

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="horizontal">���������̓��͒l</param>
    void FlipX(float horizontal)
    {
        /*
      * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
      * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
      * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
      * */
        _scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            isReturn = false;
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            isReturn = true;
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }


    //�ڒn������W�����v�ł���(�W�����v���_isGround��false��true�ɖ߂��A
    //�@�@�@�@�@�@�@�@�@�@�@�@ �ڒn���Ă��鎞�ɃW�����v�ł���悤�ɂ���)  24�`31��if���ɖ߂�
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }

    private void LateUpdate()
    {
        // �A�j���[�V�����𐧌䂷��
        if (_anim)
        {
            _anim.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
            //m_anim.SetFloat("SpeedY", m_rb.velocity.y);
            _anim.SetBool("_isGround", _isGround);
        }
    }
}

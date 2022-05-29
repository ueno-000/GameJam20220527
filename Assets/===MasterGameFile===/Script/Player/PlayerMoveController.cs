using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    /// <summary>
    /// PlayerのMoveValue
    /// </summary>
    [SerializeField] public float _speed = 5f; //SerializeField...unity内で設定(数値なら数値)を変えられる
    [SerializeField] float _jumpPower = 10f;

    /// <summary> 銃弾(bullet) </summary>
    [SerializeField] GameObject _bullet;
    /// <summary> 銃口(Muzzle) </summary>
    [SerializeField] Transform _muzzle;
    
    /// <summary>接地判定</summary>
    bool _isGround; //bool...真偽(true or false)の判定

    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool _flipX = false;
    /// <summary>反転判定</summary>
    public bool isReturn;

    /// <summary> 水平方向の入力値</summary>
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
        　　　　　　　　  //↑↓InputManagerで"Horizontal","Jump"が作られているから(GetKeyCode"Space")といったことをしなくていい
        if (Input.GetButtonDown("Jump") && _isGround == true)
            //"Jump"のキーが押され、かつ、_isGroundがtrueの時に実行される
        {
            _rb.AddForce(Vector2.up*_jumpPower,ForceMode2D.Impulse); //Vector2...2次元(Vector2.up...y軸方向に力が加えられる)
             //↑ここまででジャンプはできる
             //着地以降の操作
           _isGround = false; //_isGroundを「true → false」に変更
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

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
      * 左を入力されたらキャラクターを左に向ける。
      * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
      * Sprite Renderer の Flip:X を操作しても反転する。
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


    //接地したらジャンプできる(ジャンプ後に_isGroundをfalse→trueに戻し、
    //　　　　　　　　　　　　 接地している時にジャンプできるようにする)  24～31のif文に戻る
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
        // アニメーションを制御する
        if (_anim)
        {
            _anim.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
            //m_anim.SetFloat("SpeedY", m_rb.velocity.y);
            _anim.SetBool("_isGround", _isGround);
        }
    }
}

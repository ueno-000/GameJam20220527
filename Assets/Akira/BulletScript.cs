using UnityEngine;

/// <summary>
/// 弾丸を制御するコンポーネント
/// </summary>
public class BulletScript : MonoBehaviour
{
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float _lifeTime = 5f;

    private PlayerMoveController player;

    public bool isReturn = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMoveController>();
        // 右方向に飛ばす
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (player.isReturn != true)
        {
            rb.velocity = Vector2.right * _speed;
        }
        else
        {
            rb.velocity = Vector2.left * _speed;
        }
        // 生存期間が経過したら自分自身を破棄する
        Destroy(this.gameObject, _lifeTime);
    }
}

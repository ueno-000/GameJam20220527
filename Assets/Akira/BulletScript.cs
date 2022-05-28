using UnityEngine;

/// <summary>
/// ’eŠÛ‚ğ§Œä‚·‚éƒRƒ“ƒ|[ƒlƒ“ƒg
/// </summary>
public class BulletScript : MonoBehaviour
{
    /// <summary>’e‚ª”ò‚Ô‘¬‚³</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>’e‚Ì¶‘¶ŠúŠÔi•bj</summary>
    [SerializeField] float _lifeTime = 5f;
    /// <summary>UŒ‚’l</summary>
    [Header("e’e‚ÌUŒ‚’l"), SerializeField] public int _damageValue = 2;
    private PlayerMoveController player;

    public bool isReturn = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMoveController>();
        // ‰E•ûŒü‚É”ò‚Î‚·
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (player.isReturn != true)
        {
            rb.velocity = Vector2.right * _speed;
        }
        else
        {
            rb.velocity = Vector2.left * _speed;
        }
        // ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<IDamage>().ReceiveDamage(_damageValue);
        }

        Destroy(this.gameObject,1f);
    }
}

using UnityEngine;

/// <summary>
/// �e�ۂ𐧌䂷��R���|�[�l���g
/// </summary>
public class BulletScript : MonoBehaviour
{
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float _lifeTime = 5f;
    /// <summary>�U���l</summary>
    [Header("�e�e�̍U���l"), SerializeField] public int _damageValue = 2;
    private PlayerMoveController player;

    public bool isReturn = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMoveController>();
        // �E�����ɔ�΂�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (player.isReturn != true)
        {
            rb.velocity = Vector2.right * _speed;
        }
        else
        {
            rb.velocity = Vector2.left * _speed;
        }
        // �������Ԃ��o�߂����玩�����g��j������
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

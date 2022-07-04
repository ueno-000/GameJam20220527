using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerValueScript : MonoBehaviour,IDamage
{
    [Header("Debugモード：?するとダメージを受けない"), SerializeField] bool _debugMode;
    /// <summary>
    /// HPの値
    /// </summary>
    [SerializeField] public static int _playerHP = 100;
    int _maxHP;

    [SerializeField] GameObject HPController;
    [SerializeField] HPController _health;

    Animator _anim;
    // Start is called before the first frame update

    public int HP
    {
        set
        {
            _playerHP = Mathf.Clamp(value,0,_maxHP);
        }
        get
        {
            return _playerHP;
        }
    }

    private void Awake()
    {
        _playerHP = 100;
    }

    void Start()
    {
        _maxHP = HPController.GetComponent<HPController>()._maxHP;
        _health = _health.GetComponent<HPController>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _health.UpdateSlider(_playerHP);
        
    }

    public void ReceiveDamage(int damage)
    {
        if (_debugMode == false)
        {
            _playerHP -= damage;
            _anim.SetTrigger("damageTrigger");
        }
    }
}

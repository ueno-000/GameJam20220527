using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerValueScript : MonoBehaviour,IDamage
{
    /// <summary>
    /// HP‚Ì’l
    /// </summary>
    [SerializeField] int _playerHP = 20;
    int _maxHP;

    [SerializeField] GameObject HPController;
    [SerializeField] HPController _health;
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

    void Start()
    {
        _maxHP = HPController.GetComponent<HPController>()._maxHP;
        _health = _health.GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {
        _health.UpdateSlider(_playerHP);
        
    }

    public void ReceiveDamage(int damage)
    {
        _playerHP -= damage;
    }
}

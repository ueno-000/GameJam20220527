using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerValueScript : MonoBehaviour
{
    /// <summary>
    /// HP‚Ì’l
    /// </summary>
    [SerializeField] int _payerHP = 20;
    int _maxHP;

    [SerializeField] GameObject HPController;
    [SerializeField] HPController _helth;
    // Start is called before the first frame update

    public int HP
    {
        set
        {
            _payerHP = Mathf.Clamp(value,0,_maxHP);
        }
        get
        {
            return _payerHP;
        }
    }

    void Start()
    {
        _maxHP = HPController.GetComponent<HPController>()._maxHP;
        _helth = _helth.GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {
        _helth.UpdateSlider(_payerHP);
        
    }
}

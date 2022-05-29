using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] public int _maxHP = 5;
   [HideInInspector] public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //�X���C�_�[�ő�l�̐ݒ�E�J�n���ꂽ���������
        hpSlider.maxValue = _maxHP;
    }

    // Update is called once per frame
    /// <summary>
    /// HP���X���C�_�[�ɕ\�������郁�\�b�h
    /// </summary>
    public void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp,0,_maxHP);//(���݂̒l,�ŏ��l,�ő�l)�����Ő������Ă���
        hpSlider.value = hp;//hpSlider�̒l�Ƀv���C���[��hp��������
    }
}

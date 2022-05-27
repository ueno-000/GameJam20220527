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
        //スライダー最大値の設定・開始されたら代入される
        hpSlider.maxValue = _maxHP;
    }

    // Update is called once per frame
    /// <summary>
    /// HPをスライダーに表示させるメソッド
    /// </summary>
    public void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp,0,_maxHP);//(現在の値,最小値,最大値)ここで制限している
        hpSlider.value = hp;//hpSliderの値にプレイヤーのhpを代入する
    }
}

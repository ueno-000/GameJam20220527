using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] public int _maxHP = 5;
    [HideInInspector] public Slider hpSlider;
    bool isReturn;
    GameObject _player;
    GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _player = transform.root.gameObject;
        _canvas = transform.parent.gameObject;
        hpSlider = GetComponent<Slider>();
        isReturn = _player.GetComponent<PlayerMoveController>().isReturn;
        //スライダー最大値の設定・開始されたら代入される
        hpSlider.maxValue = _maxHP;
    }

    // Update is called once per frame
    /// <summary>
    /// HPをスライダーに表示させるメソッド
    /// </summary>
    public void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP);//(現在の値,最小値,最大値)ここで制限している
        hpSlider.value = hp;//hpSliderの値にプレイヤーのhpを代入する
    }

    void LateUpdate()
    {
        isReturn = _player.GetComponent<PlayerMoveController>().isReturn;

        if (isReturn)
        {
            _canvas.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            _canvas.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}

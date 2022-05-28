using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
   GameManager gameManager;

    [SerializeField] Text _scoreText;

    int _minScore = 0;
    int _score = 1000;

    void Start()
    {
       
        // 指定したupdateNumberまでカウントアップ・カウントダウンする
        DOTween.To(
            () => _minScore,
            (n) => _minScore = n,// 値の更新
            _score,// 最終的な値
            5.0f// アニメーション時間
            )
            .OnUpdate(
            () => _scoreText.text = _minScore.ToString("#,0")
         );
    }
}



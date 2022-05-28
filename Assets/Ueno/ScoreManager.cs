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
       
        // �w�肵��updateNumber�܂ŃJ�E���g�A�b�v�E�J�E���g�_�E������
        DOTween.To(
            () => _minScore,
            (n) => _minScore = n,// �l�̍X�V
            _score,// �ŏI�I�Ȓl
            5.0f// �A�j���[�V��������
            )
            .OnUpdate(
            () => _scoreText.text = _minScore.ToString("#,0")
         );
    }
}



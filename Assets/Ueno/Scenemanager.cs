using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Scenemanager : MonoBehaviour
{
    [Header("�C���[�W��\��t����")]
    [SerializeField] Image _fadeImage;
    public void StartFadeOut(string scene)//�t�F�[�h�A�E�g�֐�
    {
        _fadeImage.gameObject.SetActive(true);
        this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
        //Image��Color�͓����ɐݒ�
    }
    public void StartFadeIn()//�t�F�[�h�C���֐�
    {
        this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
        //Image��Color�͐^�����ɐݒ�
    }
    public void Fade(bool type, string scene)//�Ăяo���֐�
    {
        if (type)
        {
            this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
            //Image��Color�͐^�����ɐݒ�
        }
        else
        {
            _fadeImage.gameObject.SetActive(true);
            this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
            //Image��Color�͓����ɐݒ�
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}

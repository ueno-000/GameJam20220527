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
        //���X�ɈÂ����遨Scene��J�ڂ���
        this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
        //Image��Color�͓����ɐݒ�
    }
    public void StartFadeIn()//�t�F�[�h�C���֐�
    {
        //���X�ɖ��邭���遨�t�F�[�h�Ɏg���Ă����p�l�����\���ɂ���
        this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
        //Image��Color�͐^�����ɐݒ�
    }

    public void Fade(bool type, string scene)//�Ăяo���֐�
    {
        //�t�F�[�h�C���֐��Ɠ�������
        if (type)// type = true:Scene�J�ڂ�����ɌĂяo�������Bstring scene�̕�����null�ƋL�q����K�v������B
        {
            this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
            //Image��Color�͐^�����ɐݒ�
        }
        //�t�F�[�h�A�E�g�֐��Ɠ�������
        else//type = false:panel��activ�ɂ�����Scene�J�ڂ��邩��string scene�̋L�q���K�v
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

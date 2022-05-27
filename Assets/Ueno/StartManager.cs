using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] Scenemanager _sceneManager;
    [Header("FadePanel���A�N�e�B�u�ɂ��ăA�^�b�`"), SerializeField] Image _fadePanel;
    void Start()
    {
        _fadePanel.color = Color.black;
        _sceneManager.Fade(true, null);
    }
}

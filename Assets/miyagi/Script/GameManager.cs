using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,IGetValue
{
    [SerializeField]public static int _score = 0;
    [SerializeField]public Text scoreText;
    [SerializeField] GameObject config;
    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        if (PlayerValueScript._playerHP <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }  //      if()
       scoreText.text = _score.ToString();
    }
 public void GetPoint(int score)
    {
        _score += score;
    }

   /* private void Update()
    {
        if(_playerHp <= 0)
        {
            isGameOver = true;
        }
    }*/
}

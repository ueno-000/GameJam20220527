using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int _score;

    public Text _resultScore;
    void Start()
    {
        _resultScore.text = "Score :" + _score;
    }
    public void AddScore(int addScore)
    {
        _score += addScore;
        _resultScore.text = "Score :" + _score;
    }

   /* private void Update()
    {
        if(_playerHp <= 0)
        {
            isGameOver = true;
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,IGetValue
{

    public ScoreManager scoreMana;
    [SerializeField]public int _score = 0;

    public Text _resultScore;
    void Start()
    {
        scoreMana.GetComponent<ScoreManager>();
        //_resultScore.text = "Score :" + scoreMana._score;
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

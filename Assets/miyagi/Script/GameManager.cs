using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,IGetValue
{

    [SerializeField]public int _score = 0;
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

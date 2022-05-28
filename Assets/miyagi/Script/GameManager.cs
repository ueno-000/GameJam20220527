using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,IGetValue
{
    private PlayerValueScript pvs;
    [SerializeField]public static int _score = 0;

    void Start()
    {
        pvs = GetComponent<PlayerValueScript>();
    }

    void Update()
    {
        if(pvs._playerHP <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
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

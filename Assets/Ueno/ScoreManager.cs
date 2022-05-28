using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour,IGetValue
{
    [SerializeField] int _score = 0;

    public void GetPoint(int score)
    {
        _score += score;
    }
}

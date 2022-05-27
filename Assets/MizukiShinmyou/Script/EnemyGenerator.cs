using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]List<GameObject> enemyList;
    [SerializeField]Transform pos;
    [SerializeField]Transform pos2;
    float minX, maxX, minY, maxY;
    int _frame = 0;
    [SerializeField] int _genarateFram = 30;

    void Start()
    {
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
        maxY = Mathf.Min(pos.position.y, pos2.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        _frame++;
        if (_frame > _genarateFram)
        {
            _frame = 0;
            int Index = Random.Range(0, enemyList.Count);
            float posX = Random.Range(minX,maxX);
            float posY = Random.Range(minY,maxY);
            Instantiate(enemyList[Index], new Vector3(posX, posY, 0), Quaternion.identity);
        }

        
    }
}

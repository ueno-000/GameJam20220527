using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : ItemBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PickItem();
            //_playerHp++;
        }
    }
    public override void PickItem()
    {
        base.PickItem();
    }
}

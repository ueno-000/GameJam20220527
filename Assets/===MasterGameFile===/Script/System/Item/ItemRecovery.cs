using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecovery : ItemBase
{
    [SerializeField] int _recoveryValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IDamage>().ReceiveDamage(_recoveryValue);
            Destroy(gameObject);
        }
    }
    public override void PickItem()
    {
        base.PickItem();
    }
}

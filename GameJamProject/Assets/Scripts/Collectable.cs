using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.gameObject.GetComponent<Inventory>();
        if(inventory)
        {
            bool pickUp = inventory.pickUpItem(gameObject);
            if(pickUp)Destroy(gameObject);
        }

    }
}

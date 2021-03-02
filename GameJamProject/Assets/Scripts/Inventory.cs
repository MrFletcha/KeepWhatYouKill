using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory current;
    public int keyCount;
    public int equipment;

    private void Start()
    {
        current = this;
    }

    public bool pickUpItem(GameObject obj)
    {
        switch(obj.tag)
        {
            case Constants.Tag_Key:
                keyCount++;
                return true;

            default:
                Debug.LogWarning($"Warning: No pickUp in place for obj {obj} with tag {obj.tag}");
                return false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Inventory inventory = player.GetComponent<Inventory>();
            if(inventory && inventory.keyCount > 0)
            {
                animator.SetBool("HasKey", true);
            }
        }
    }
}

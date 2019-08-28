using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player.inventory.keys > 0)
        {
            GameManager.managerInstance.audioManager.PlayInteractSound();
            player.inventory.keys--;
            Destroy(gameObject);
        }
    }
}

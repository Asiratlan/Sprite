using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactableItem = collision.gameObject.GetComponent<AttackInterectable>();
        if (interactableItem != null)
        {
            interactableItem.Interact();
        }

        var component = collision.gameObject.GetComponent<Enemy>();
        if (component != null)
        {
            Vector2 difference = collision.transform.position - transform.position;    
            component.Damage(damage);
            GameManager.managerInstance.audioManager.PlayDamageSound();
        }
    }
}

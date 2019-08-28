using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public float damage;
    public bool destroyOnImpact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var breakableItem = collision.gameObject.GetComponent<BreakableItem>();
        if (breakableItem != null)
        {
            breakableItem.Interact();
        }

        var component = collision.gameObject.GetComponent<Player>();
        if (component != null)
        {
            Vector2 difference = collision.transform.position - transform.position;
            component.Damage(damage);
            GameManager.managerInstance.audioManager.PlayDamageSound();
            component.animator.SetTrigger("Damaged");
            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}

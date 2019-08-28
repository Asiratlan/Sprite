using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Entity entity = other.GetComponent<Entity>();
            if (entity.health > 0)
            {
                Vector2 diff = other.transform.position - transform.position;
                diff = diff.normalized * thrust;
                entity.body.AddForce(diff, ForceMode2D.Impulse);
                if (entity is Enemy)
                    ((Enemy)entity).controller.aiPath.canMove = false;
                StartCoroutine(KnockCo(entity));
            }
        }
    }
    //Knockback Coroutine
    public IEnumerator KnockCo(Entity entity)
    {
        yield return new WaitForSeconds(knockTime);
        if (entity.body != null)
        {
            entity.body.velocity = Vector2.zero;
            if (entity is Enemy)
                ((Enemy)entity).controller.aiPath.canMove = true;
        }
    }
}

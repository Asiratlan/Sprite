using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

class UnicornBoss : Enemy
{
    public PolygonCollider2D bossArea;
    
    public override void Damage(float damage)
    {
        animator.SetTrigger("damage");
        health -= damage;
        if (health <= 0)
        {
            GameManager.managerInstance.audioManager.PlayKillSound();
            Destroy(this.gameObject);
        }

        else
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        var bounds = bossArea.bounds;
        var center = bounds.center;

        float x = 0;
        float y = 0;
        do
        {
            x = UnityEngine.Random.Range(center.x - bounds.extents.x, center.x + bounds.extents.x);
            y = UnityEngine.Random.Range(center.y - bounds.extents.y, center.y + bounds.extents.y);
        } while (Physics2D.OverlapPoint(new Vector2(x, y), LayerMask.NameToLayer("Area")) == null);

        gameObject.transform.position = new Vector2(x, y);
    }
}

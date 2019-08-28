using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : AttackInterectable
{
    public GameObject brokenObject;

    public override void Interact()
    {
        if (brokenObject != null)
        {
            Instantiate(brokenObject, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}

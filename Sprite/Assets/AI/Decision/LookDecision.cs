using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var direction = controller.entity.movement;
        Debug.DrawRay(controller.transform.position, direction * 10, Color.red);

        //do the ray test
        RaycastHit2D[] sightTestResults = Physics2D.RaycastAll(controller.transform.position, direction, 10);
        foreach (var result in sightTestResults)
        {
            //If a Solid Collision item is in the way, it can't see the player
            if (result.collider.gameObject.tag == "Collision")
                return false;

            Debug.Log("Rigidbody collider is: " + result.collider);
            if (result.collider.gameObject == player)
                return true;

        }

        return false;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/CanShootPlayer")]

class CanShootPlayerDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return IsTorwardPlayer(controller) && IsTargetNear(controller);
    }

    public bool IsTorwardPlayer(StateController controller)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var direction = controller.entity.movement;
        float dot = Vector3.Dot(direction, (player.transform.position - controller.transform.position).normalized);
        if (dot > 0.7f) {
            /* Debug.Log("Quite facing"); */
            return true;
        }
        return false;
    }

    private bool IsTargetNear(StateController controller)
    {
        return Vector3.Distance(controller.destination.target.position, controller.transform.position) < 7.0f;
    }
}

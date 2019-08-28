using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/PlayerDistance")]
public class PlayerDistanceDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool ennemyTooFar = isTargetNear(controller);
        return ennemyTooFar;
    }

    private bool isTargetNear(StateController controller)
    {
        return Vector3.Distance(controller.destination.target.position, controller.transform.position) < 10.0f;
    }
}
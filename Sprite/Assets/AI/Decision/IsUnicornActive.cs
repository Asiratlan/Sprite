using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/UnicornActive")]
public class IsUnicornActive : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.aiActive;
    }
}
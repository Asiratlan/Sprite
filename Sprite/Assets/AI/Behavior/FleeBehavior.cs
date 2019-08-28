using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/Flee")]

    class FleeBehavior : EnemyBehavior
    {
        public override void Execute(StateController controller)
        {
            controller.aiPath.canMove = true;
        }
    }
}

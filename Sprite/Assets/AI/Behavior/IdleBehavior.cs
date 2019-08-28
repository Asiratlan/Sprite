using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/Idle")]
    class IdleBehavior : EnemyBehavior
    {
        public override void Execute(StateController controller)
        {
            controller.entity.isMoving = false;
            controller.aiPath.enabled = false;
        }
    }
}

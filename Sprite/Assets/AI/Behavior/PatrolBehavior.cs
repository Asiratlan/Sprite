using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/Patrol")]
    class PatrolBehavior : EnemyBehavior
    {
        public override void Execute(StateController controller)
        {
            // e.destination.enabled = false;
            var direction = controller.aiPath.destination - controller.transform.position;
            controller.entity.isMoving = true;
            controller.entity.movement = direction.normalized;     
            controller.aiPath.enabled = true;
            controller.patrol.enabled = true;
            controller.destination.enabled = false;
        }
    }
}

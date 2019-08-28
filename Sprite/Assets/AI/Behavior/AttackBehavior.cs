using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/Attack")]
    class AttackBehavior : EnemyBehavior
    {
        public override void Execute(StateController controller)
        {
            controller.aiPath.enabled = true;
            controller.destination.enabled = true;
            controller.patrol.enabled = false;
            controller.destination.target = GameObject.FindGameObjectWithTag("Player").transform;
            controller.entity.isMoving = true;
            controller.entity.movement = controller.aiPath.desiredVelocity;
        }
    }
}

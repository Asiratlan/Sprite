using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/RangeAttack")]
    class RangeAttackBehavior : EnemyBehavior
    {
        public float shotDelay;
        private float _timeToWait;
        public override void Execute(StateController controller)
        {
            _timeToWait -= Time.deltaTime;
            if (_timeToWait <= 0)
            {
                _timeToWait = shotDelay;
                controller.aiPath.enabled = false;
                controller.destination.enabled = false;
                controller.patrol.enabled = false;
                controller.entity.isMoving = false;
                controller.entity.animator.SetTrigger("Attack");
            }
        }
    }
}

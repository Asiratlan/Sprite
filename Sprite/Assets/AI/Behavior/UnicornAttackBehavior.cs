using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/UnicornAttack")]
    class UnicornAttackBehavior : EnemyBehavior
    {
        public override void Execute(StateController controller)
        {
            foreach (var projectileEmitter in controller.gameObject.GetComponents<ProjectileEmitter>())
            {
                projectileEmitter.enabled = true;
            }
        }
    }
}

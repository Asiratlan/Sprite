using UnityEngine;

namespace Assets.Behavior
{
    [CreateAssetMenu(menuName = "PluggableAI/Behavior/UnicornIdle")]
    class UnicornIdleBehavior : EnemyBehavior
    {
        public override void Execute(StateController controller)
        {
            foreach (var projectileEmitter in controller.gameObject.GetComponents<ProjectileEmitter>())
            {
                projectileEmitter.enabled = false;
            }
        }
    }
}

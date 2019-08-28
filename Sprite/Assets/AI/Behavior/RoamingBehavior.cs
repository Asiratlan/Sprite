using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Behavior/Roaming")]

public class RoamingBehavior : EnemyBehavior
{
    public const float StateDuration = 2;
    
    private float _timeDelta = StateDuration;

    public override void Execute(StateController controller)
    {
        _timeDelta += Time.deltaTime;
        controller.destination.enabled = false;
        controller.patrol.enabled = false;
        controller.aiPath.enabled = false;
        var rb = controller.entity.body;
        Vector2 direction ;

        if (_timeDelta > StateDuration)
        {
            _timeDelta = 0;
            direction = GetRandomDirection();
            while (direction == GetOppositeDirection(controller.entity.movement))
                direction = GetRandomDirection();
            controller.entity.movement = direction;
        }

        controller.entity.isMoving = true;
        rb.MovePosition(rb.position + Time.deltaTime * controller.aiPath.maxSpeed * controller.entity.roamingFactor * controller.entity.movement);
    }

    public static Vector2 GetRandomDirection()
    {
        var direction = Random.Range(0, 4);
        
        switch (direction)
        {
            case 0:
                return Vector2.up;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.down;
            case 3:
                return Vector2.right;
        }
        
        return Vector2.zero;
    }

    public static Vector2 GetOppositeDirection(Vector2 dir)
    {
        return new Vector2(dir.y, dir.x);
    }
}
using UnityEngine;
using UnityEditor;

public class NPC : Entity
{
    public override void Damage(float damage)
    {
        return;
    }

    private void Update()
    {
        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);
    }
}
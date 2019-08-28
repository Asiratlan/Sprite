using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotArrow : StateMachineBehaviour
{
    public Rigidbody2D weaponPrefab;
    public float speed;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var controller = animator.gameObject.GetComponent<StateController>();
        Vector3 directionVector = controller.entity.movement;
        var angle = Vector2.Angle(Vector2.up, directionVector);
        var arrow = Instantiate(weaponPrefab, controller.transform.position + directionVector, Quaternion.Euler(0, 0, -angle));
        arrow.AddForce(100 * directionVector * speed);
        Destroy(arrow.gameObject, 5);
    }
}

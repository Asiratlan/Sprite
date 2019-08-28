using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    public StateController controller;
    [HideInInspector] public Vector3 originalPosition;

    // Update is called once per frame
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        animator.SetBool("IsMoving", isMoving);
        var direction = RoundVector(movement.normalized);
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }

    private void OnDestroy()
    {
        foreach(Transform t in controller.patrol.targets)
        {
            Destroy(t.gameObject);
        }

        if (controller.destination.target != null && controller.destination.target.gameObject != GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(controller.destination.target);
        }
    }

    public override void Damage(float damage)
    {
        animator.SetTrigger("damage");
        health -= damage;
        if (health <= 0)
        {
            GameManager.managerInstance.audioManager.PlayKillSound();
            Destroy(this.gameObject);
        }
    }
}

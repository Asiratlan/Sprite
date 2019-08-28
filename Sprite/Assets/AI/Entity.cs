using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public Animator animator;
    public Vector2 movement;
    public bool isMoving;
    public float roamingFactor;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public abstract void Damage(float damage);

    public Vector2 RoundVector(Vector2 vec)
    {
        var x = Mathf.Abs(vec.x);
        var y = Mathf.Abs(vec.y);
        if (x > y)
        {
            return new Vector2(vec.x < 0 ? -1 : 1, 0);
        }

        else
        {
            return new Vector2(0, vec.y < 0 ? -1 : 1);
        }
    }
}

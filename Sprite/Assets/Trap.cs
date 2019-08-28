using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public List<Switch> switches;
    public Animator animator;
    private Weapon _weapon;

    public void Start()
    {
        animator = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
    }

    public void Update()
    {
        var active = isActive();
        animator.SetBool("activated", active);
        _weapon.enabled = active;
        foreach(BoxCollider2D c in GetComponents<BoxCollider2D>())
        {
            c.enabled = active;
        }
    }

    public bool isActive()
    {
        return switches.TrueForAll(s => s.isActive);
    }
}

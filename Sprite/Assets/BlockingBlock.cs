using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class BlockingBlock : MonoBehaviour
{
    public Switch tiedSwitch;
    private Animator _animator;
    private BoxCollider2D _collider;
    public bool followSwitch;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        var active = isActive();
        _animator.SetBool("activated", active);
        _collider.enabled = active;
    }

    public bool isActive()
    {
        return tiedSwitch.isActive ^ followSwitch;
    }
}

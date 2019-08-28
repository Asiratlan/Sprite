using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private Animator _animator;
    public ChestItem item;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        spriteRenderer.sprite = item.sprite;
    }
    public override void Interact()
    {
        spriteRenderer.gameObject.SetActive(true);
        _animator.SetTrigger("Open");
        GameManager.managerInstance.audioManager.PlayChestJingle();

    }
}

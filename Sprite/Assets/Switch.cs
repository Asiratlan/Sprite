using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : AttackInterectable
{
    public bool isActive;
    public Sprite onSprite;
    public Sprite offSprite;
    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        changeSwitch();  
        GameManager.managerInstance.audioManager.PlaySwitchSound();
    }

    public void changeSwitch()
    {
        isActive = !isActive;
        _spriteRenderer.sprite = isActive ? onSprite : offSprite;
    }
}

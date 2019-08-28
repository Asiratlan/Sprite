using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public List<UnityEngine.UI.Image> heartComponents;
    public List<Sprite> heartSprites;
    public TextMeshProUGUI keyText;
    private Player _player;

    public Sprite swordSprite;
    public Sprite chakramSprite;
    public Sprite bombSprite;
    public Image weaponSprite;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < heartComponents.Count; ++i)
        {
            heartComponents[i].enabled = _player.maxHealth > i;

            int partMax = heartSprites.Count - 1;
            var partsToDraw = Math.Round((_player.health - i) * partMax);
            if (partsToDraw < 0) partsToDraw = 0;
            if (partsToDraw > heartSprites.Count - 1) partsToDraw = heartSprites.Count - 1;

            heartComponents[i].sprite = heartSprites[(int)Math.Floor(partsToDraw)];
        }

        keyText.text = _player.inventory.keys.ToString();

        if (_player.weapon == PlayerEquipment.Weapon.Chakram)
            weaponSprite.sprite = chakramSprite;

        if (_player.weapon == PlayerEquipment.Weapon.Sword)
            weaponSprite.sprite = swordSprite;

        if (_player.weapon == PlayerEquipment.Weapon.Bomb)
            weaponSprite.sprite = bombSprite;
    }
}

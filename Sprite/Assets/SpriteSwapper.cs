﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Based on https://www.erikmoberg.net/article/unity3d-replace-sprite-programmatically-in-animation

public class SpriteSwapper : MonoBehaviour
{
    // The name of the sprite sheet to use
    public string SpriteSheetName;

    // The name of the currently loaded sprite sheet
    private string LoadedSpriteSheetName;

    // The dictionary containing all the sliced up sprites in the sprite sheet
    private Dictionary<string, Sprite> spriteSheet;

    // The Unity sprite renderer so that we don't have to get it multiple times
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    private void Start()
    {
        // Get and cache the sprite renderer for this game object
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        this.LoadSpriteSheet();
    }

    // Runs after the animation has done its work
    private void LateUpdate()
    {
        // Check if the sprite sheet name has changed (possibly manually in the inspector)
        if (this.LoadedSpriteSheetName != this.SpriteSheetName)
        {
            // Load the new sprite sheet
            this.LoadSpriteSheet();
        }

        // Swap out the sprite to be rendered by its name
        // Important: The name of the sprite must be the same!
        this.spriteRenderer.sprite = this.spriteSheet[this.spriteRenderer.sprite.name];
    }

    // Loads the sprites from a sprite sheet
    private void LoadSpriteSheet()
    {
        // Load the sprites from a sprite sheet file (png). 
        // Note: The file specified must exist in a folder named Resources
        var sprites = Resources.LoadAll<Sprite>(this.SpriteSheetName);
        this.spriteSheet = sprites.ToDictionary(x => x.name, x => x);

        // Remember the name of the sprite sheet in case it is changed later
        this.LoadedSpriteSheetName = this.SpriteSheetName;
    }
}

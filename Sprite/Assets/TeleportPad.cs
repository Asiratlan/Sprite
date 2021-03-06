﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{
    public Vector2 PlayerPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = PlayerPosition;
        }
    }
}
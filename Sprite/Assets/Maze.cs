using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Maze : MonoBehaviour
{
    public Color blue;
    public Color red;
    public Switch s;
    public Tilemap tilemap;
    public Tilemap collision;

    // Update is called once per frame
    void Update()
    {
        if (s.isActive)
        {
            tilemap.color = red;
            collision.color = red;
        }
        else
        {
            tilemap.color = blue;
            collision.color = blue;
        }
           
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    bool Alive;

    SpriteRenderer renderer;

    [SerializeField]
    Material aliveMaterial, deadMaterial;

    void Awake()
    {
        Alive = false;
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Alive)
        {
            renderer.material = aliveMaterial;
        } else
        {
            renderer.material = deadMaterial;
        }

    }
}

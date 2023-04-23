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

        List<Tile> neighbouringTiles = getNeighbours();


    }

    public bool isNeighbouringTile(Tile otherTile)
    {
        // Calculate the distance between this tile and the other tile
        float distance = Vector3.Distance(transform.position, otherTile.transform.position);

        // If the distance is less than or equal to the diagonal of a tile, they are considered neighbors
        return distance <= Mathf.Sqrt(2);
    }

    public List<Tile> getNeighbours()
    {
        // locate *all* tiles
        Tile[] allTiles = GameObject.FindObjectsOfType<Tile>();

        // list of neighbours
        List<Tile> neighbours = new List<Tile>();

        foreach (Tile otherTile in allTiles)
        {
            if (otherTile == this)
            {
                continue;
            }

            if (isNeighbouringTile(otherTile))
            {
                neighbours.Add(otherTile);
            }
        }
        return neighbours;
    }
}

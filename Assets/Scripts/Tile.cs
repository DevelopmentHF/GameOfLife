using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    public bool Alive, aliveBuffer;

    SpriteRenderer renderer;

    [SerializeField]
    Material aliveMaterial, deadMaterial;

    List<Tile> neighbours;

    void Awake()
    {
        Alive = false;
        aliveBuffer = false;
        renderer = GetComponent<SpriteRenderer>();
        renderer.material = deadMaterial;
    }

    void Start()
    {
        neighbours = getNeighbours();
    }

    bool IsNeighbouringTile(Tile otherTile)
    {
        // Calculate the distance between this tile and the other tile
        float distance = Vector3.Distance(transform.position, otherTile.transform.position);

        // If the distance is less than or equal to the diagonal of a tile, they are considered neighbors
        return distance <= Mathf.Sqrt(2);
    }

    List<Tile> getNeighbours()
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

            if (IsNeighbouringTile(otherTile))
            {
                neighbours.Add(otherTile);
            }
        }
        return neighbours;
    }

    void OnMouseDown()
    {
        Alive = !Alive;
        Debug.Log("clicked");

        if (Alive) {
            renderer.material = aliveMaterial;
        } else
        {
            renderer.material = deadMaterial;
        }

    }

    public int CountLiveNeighbours()
    {
        int count = 0;
        foreach(Tile neighbour in neighbours)
        {
            if (neighbour.Alive)
            {
                count++;
            }
        }
        return count;
    }

    public void UpdateVisuals()
    {
        if(Alive)
        {
            renderer.material = aliveMaterial;
        } else
        {
            renderer.material = deadMaterial;
        }
    }
    

}

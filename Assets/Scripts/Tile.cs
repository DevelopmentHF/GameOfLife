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

    List<Tile> neighbouringTiles;

    void Awake()
    {
        Alive = false;
        renderer = GetComponent<SpriteRenderer>();
        renderer.material = deadMaterial;
    }

    void Start()
    {
        neighbouringTiles = getNeighbours();
    }

    void Update()
    {
        if (Alive)
        {
            renderer.material = aliveMaterial;
        }

        if(Alive)
        {
            Debug.Log($"tile({transform.position.x}, {transform.position.y}) has these neighbours:\n");
            foreach (Tile neighbour in neighbouringTiles)
            {
                neighbour.SetMaterial(aliveMaterial);
                Debug.Log($"({neighbour.transform.position.x}, {neighbour.transform.position.y})");
            }
        }

    }

    public bool IsNeighbouringTile(Tile otherTile)
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

            if (IsNeighbouringTile(otherTile))
            {
                neighbours.Add(otherTile);
            }
        }
        return neighbours;
    }

    public void SetMaterial(Material material) {
        renderer.material = material;
        Debug.Log("changing material");
    }

}

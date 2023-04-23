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

    [SerializeField]
    float updateInterval = 1f; // Update once per second

    private float lastUpdateTime;

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

        // Check if one second has passed since the last update
        //if (Time.time - lastUpdateTime >= updateInterval)
        //{
        //    int numNeighboursAlive = 0;

        //    foreach (Tile neighbour in neighbouringTiles)
        //    {
        //        if (neighbour.Alive)
        //        {
        //            numNeighboursAlive++;
        //        }
        //    }


        //    if (Alive)
        //    {
        //        renderer.material = aliveMaterial;

        //        if (numNeighboursAlive != 2 || numNeighboursAlive != 3)
        //        {
        //            Alive = false;
        //            renderer.material = deadMaterial;
        //        }
        //    }
        //    else
        //    {
        //        if (numNeighboursAlive == 3)
        //        {
        //            Alive = true;
        //            renderer.material = aliveMaterial;
        //        }
        //    }
        //    // Update the last update time to the current time
        //    lastUpdateTime = Time.time;
        //}
        

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
}

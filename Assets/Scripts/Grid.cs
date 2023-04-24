using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    public int resolution;

    [SerializeField]
    Transform tilePrefab;

    // reference to all the tile game objects in the grid
    private Tile[] tiles;

    [SerializeField]
    float updateInterval = 0.1f; // Update 10 times a second
    private float lastUpdateTime;

    bool gameStarted = false;

    void Awake()
    {
        var position = Vector3.zero;

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                Transform tile = Instantiate(tilePrefab);

                position.x = x;
                position.y = y;

                tile.position = position;

                tile.SetParent(transform, false);

            }
        }
    }

    void Start()
    {
        // get all the Tile components of the child game objects
        tiles = GetComponentsInChildren<Tile>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = !gameStarted;
        }

        if (gameStarted)
        {
            if (Time.time - lastUpdateTime >= updateInterval)
            {
                UpdateGeneration();
                // Update the last update time to the current time
                lastUpdateTime = Time.time;
            }
        }

    }
    void UpdateGeneration()
    {
        // create a temporary grid to store the next state of each tile
        bool[,] nextState = new bool[resolution, resolution];

        foreach (Tile tile in tiles)
        {
            // Gets number of alive neighbours to current tile
            int liveNeighbours = tile.CountLiveNeighbours();

            // apply the rules of the game to determine the next state of the tile
            if (tile.Alive)
            {
                if (liveNeighbours < 2 || liveNeighbours > 3)
                {
                    // cell dies
                    nextState[(int)tile.transform.position.x, (int)tile.transform.position.y] = false;
                }
                else
                {
                    // cell survives
                    nextState[(int)tile.transform.position.x, (int)tile.transform.position.y] = true;
                }
            }
            else
            {
                if (liveNeighbours == 3)
                {
                    // cell is born
                    nextState[(int)tile.transform.position.x, (int)tile.transform.position.y] = true;
                }
                else
                {
                    // cell remains dead
                    nextState[(int)tile.transform.position.x, (int)tile.transform.position.y] = false;
                }
            }
        }

        // update the state of all tiles at once based on the temporary grid
        foreach (Tile tile in tiles)
        {
            tile.Alive = nextState[(int)tile.transform.position.x, (int)tile.transform.position.y];
            // update the tile's visual representation based on its new state
            tile.UpdateVisuals();
        }
    }

}

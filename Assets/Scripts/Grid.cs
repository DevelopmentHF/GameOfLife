using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    int resolution;

    [SerializeField]
    Transform tilePrefab;
   
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

                if ((x + y) % 2 == 1) {
                    Debug.Log($"Offet Tile at ({x}, {y})");
                }


                tile.SetParent(transform, false);

            }
        }

        Vector3 currentPosition = transform.localPosition;
        currentPosition.x -= resolution / 2;
        currentPosition.y -= resolution / 2;
        transform.localPosition = currentPosition;
    }
}

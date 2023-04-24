using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    Tile prevtile = null;

    void Drawererer()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                //Debug.Log($"Mouse is over tile ({tile.transform.position.x}, {tile.transform.position.y})");
                if (prevtile != tile) 
                {
                    Debug.Log($"changing tile ({tile.transform.position.x}, {tile.transform.position.y}");
                    tile.Alive = !tile.Alive;
                    tile.UpdateVisuals();
                    prevtile = tile;
                } 
            }
        }
    }

    private void Update()
    {
        Drawererer();
    }
}

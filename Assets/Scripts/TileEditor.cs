using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TileEditor : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile aliveTile;

    private void Update()
    {
        // Check if the pointer is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);

            if (!IsAlive(cellPos))
            {
                tilemap.SetTile(cellPos, aliveTile);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);

            if (IsAlive(cellPos))
            {
                tilemap.SetTile(cellPos, null);
            }
        }
    }

    private bool IsAlive(Vector3Int cell) => tilemap.GetTile(cell) == aliveTile;
}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Tilemap currentState;
    [SerializeField] private Tile aliveTile;
    [SerializeField] private TextMeshProUGUI populationText;
    [SerializeField] private TextMeshProUGUI iterationsText;

    private readonly HashSet<Vector3Int> aliveCells = new();
    private readonly HashSet<Vector3Int> cellsToCheck = new();

    private float updateInterval = 0.05f;
    private int population = 0;
    private int iterations = 0;

    public void AnalyzeTilemapAndStart()
    {
        // Clear any existing cells to reset the simulation
        Clear();

        // Analyze the entire Tilemap to populate aliveCells
        foreach (var pos in currentState.cellBounds.allPositionsWithin)
        {
            if (currentState.GetTile(pos) == aliveTile)
            {
                aliveCells.Add(pos);
            }
        }

        StopAllCoroutines(); // Stop any existing simulation coroutine
        StartCoroutine(Simulate());
    }

    private void Clear()
    {
        aliveCells.Clear();
        cellsToCheck.Clear();
        population = 0;
        iterations = 0;
        UpdateText();
    }

    private IEnumerator Simulate()
    {
        while (enabled)
        {
            UpdateState();

            population = aliveCells.Count;
            iterations++;

            UpdateText();

            yield return new WaitForSeconds(updateInterval);
        }
    }

    private void UpdateState()
    {
        cellsToCheck.Clear();

        // Gather cells to check
        foreach (Vector3Int cell in aliveCells)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    cellsToCheck.Add(cell + new Vector3Int(x, y));
                }
            }
        }

        // Transition cells to the next state
        foreach (Vector3Int cell in cellsToCheck)
        {
            int neighbors = CountNeighbors(cell);
            bool alive = IsAlive(cell);

            if (!alive && neighbors == 3)
            {
                aliveCells.Add(cell);
            }
            else if (alive && (neighbors < 2 || neighbors > 3))
            {
                aliveCells.Remove(cell);
            }
        }

        currentState.ClearAllTiles();
        foreach (Vector3Int cell in aliveCells)
        {
            currentState.SetTile(cell, aliveTile);
        }
    }

    private int CountNeighbors(Vector3Int cell)
    {
        int count = 0;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector3Int neighbor = cell + new Vector3Int(x, y);

                if (x == 0 && y == 0)
                {
                    continue;
                }
                else if (IsAlive(neighbor))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsAlive(Vector3Int cell) => currentState.GetTile(cell) == aliveTile;

    public void StopSimulation() => StopAllCoroutines();

    public void UpdateInterval(float value) => updateInterval = value;

    private void UpdateText()
    {
        populationText.text = "Population: " + population.ToString();
        iterationsText.text = "Iterations: " + iterations.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    Queue<Tile> FloodFill(Tile start, Tile goal)
    {
        Dictionary<Tile, Tile> nextTileToGoal = new Dictionary<Tile, Tile>();
        Queue<Tile> frontier = new Queue<Tile>();
        List<Tile> visited = new List<Tile>();

        frontier.Enqueue(goal);

        while (frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();

            foreach (Tile neighbor in _mapGenerator.Neighbors(curTile))
            {
                if (visited.Contains(neighbor) == false && frontier.Contains(neighbor) == false)
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        frontier.Enqueue(neighbor);
                        nextTileToGoal[neighbor] = curTile;
                    }
                }
            }
            visited.Add(curTile);
        }

        if (visited.Contains(start) == false)
            return null;

        Queue<Tile> path = new Queue<Tile>();
        Tile curPathTile = start;
        while (curPathTile != goal)
        {
            curPathTile = nextTileToGoal[curPathTile];
            path.Enqueue(curPathTile);
        }

        return path;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

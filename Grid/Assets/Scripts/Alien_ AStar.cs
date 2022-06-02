using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Queue<Tile> AStar(Tile start, Tile goal)
    {
        Dictionary<Tile, Tile> NextTileToGoal = new Dictionary<Tile, Tile>();//Determines for each tile where you need to go to reach the goal. Key=Tile, Value=Direction to Goal
        Dictionary<Tile, int> costToReachTile = new Dictionary<Tile, int>();//Total Movement Cost to reach the tile

        PriorityQueue<Tile> frontier = new PriorityQueue<Tile>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();
            if (curTile == start)
                break;

            foreach (Tile neighbor in _mapGenerator.Neighbors(curTile))
            {
                int newCost = costToReachTile[curTile] + neighbor._Cost;
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        costToReachTile[neighbor] = newCost;
                        int priority = newCost + Distance(neighbor, start);
                        frontier.Enqueue(neighbor, priority);
                        NextTileToGoal[neighbor] = curTile;
                        neighbor._Text = costToReachTile[neighbor].ToString();
                    }
                }
            }
        }

        //Get the Path

        //check if tile is reachable
        if (NextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }

        Queue<Tile> path = new Queue<Tile>();
        Tile pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
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

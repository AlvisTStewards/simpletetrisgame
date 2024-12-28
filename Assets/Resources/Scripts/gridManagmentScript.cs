using System;
using UnityEngine;

public class gridManagmentScript : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;
    private static Transform[,] grid = new Transform[width, height];


     public static bool IsInsideGrid(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < width && pos.y >= 0;
    }

    public static void AddToGrid(Transform tetromino)
    {
        foreach (Transform block in tetromino)
        {
            Vector2 pos = Round(block.position);
            grid[(int)pos.x, (int)pos.y] = block;
        }
    }

    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < width; x++)
            if (grid[x, y] == null) return false;
        return true;
    }

    public static void DeleteRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void MoveRowsDown(int startY)
    {
        for (int y = startY; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }

    public static Vector2 Round(Vector2 pos) => new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));

    internal static bool IsOccupied(Vector2 pos)
    {
        return grid[(int)pos.x, (int)pos.y] != null;
    }
}

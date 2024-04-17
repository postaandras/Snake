using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{

    public static CollectionController instance;

    private void Awake()
    {
        instance = this;
    }

    public void AppleSpawner(LinkedList<Tile> snakePositions)
    {
        Tile[,] currentBoard = GridController.instance.GetBoard();
        int size = GridController.instance.GetGridSize();

        int randomX = Random.Range(0, size);
        int randomY = Random.Range(0, size);

        if (!snakePositions.Contains(currentBoard[randomX, randomY]))
        {
            currentBoard[randomX, randomY].SetToApple();
        }
        else
        {
            AppleSpawner(snakePositions);
        }
    }
}

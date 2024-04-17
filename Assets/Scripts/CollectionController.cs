using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{

    public static CollectionController instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleSpawner(LinkedList<Tile> snakePositions)
    {
        Tile[,] currentBoard = GridController.instance.GetBoard();
        int randomX = Random.Range(0, GridController.instance.GetGridSize());
        int randomY = Random.Range(0, GridController.instance.GetGridSize());

        if (!snakePositions.Contains(currentBoard[randomX, randomY]))
        {
            currentBoard[randomX, randomY].setToApple();
        }
        else
        {
            AppleSpawner(snakePositions);
        }
    }
}

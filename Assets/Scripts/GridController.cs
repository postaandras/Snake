using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridController : MonoBehaviour
{

    [SerializeField] private int gridSize;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int tileWidth;
    [SerializeField] private Camera sceneCamera;

    public int GridSize { get { return gridSize; } }

    private Tile[,] board;
    private GameObject tilesParent;

    public static GridController instance;

    public void InitializeGame()
    {
        board = new Tile[gridSize, gridSize];

        Reset();

        GenerateGrid();

        InitializeSnake();

        sceneCamera.transform.position = new Vector3(gridSize / 2 - 0.5f, gridSize / 2 - 0.5f, -10);

        CollectionController.instance.AppleSpawner(MovementController.instance.GetSnakeTiles());

        MovementController.instance.SetDirection(MoveDirection.RIGHT);
    }
    void Awake()
    {
        instance = this;
    }


    private void GenerateGrid()
    {
        tilesParent = new GameObject("Tiles");
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject currentTile = Instantiate(tilePrefab, new Vector3(i, j, 0), Quaternion.identity);
                currentTile.transform.SetParent(tilesParent.transform);
                board[i, j] = currentTile.GetComponent<Tile>();
                board[i, j].SetX(i);
                board[i, j].SetY(j);

            }
        }
    }

    private void Reset()
    {
        if (tilesParent != null) Destroy(tilesParent);

    }

    private void InitializeSnake()
    {
        AddToSnake(2, gridSize/2);
        AddToSnake(3, gridSize/2);
        AddToSnake(4, gridSize/2);

    }

    private void AddToSnake(int i, int j)
    {
        MovementController.instance.AddToSnake(board[i, j]);
        board[i, j].SetToSnake();
    }


    public Tile[,] GetBoard() { return board; }
}

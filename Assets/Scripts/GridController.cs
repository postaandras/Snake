using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridController : MonoBehaviour
{

    [SerializeField] int gridSize;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int tileWidth;

    [SerializeField] Camera sceneCamera;

    private Tile[,] board;
    private List<GameObject> Tiles = new List<GameObject>();

    public static GridController instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
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


    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject currentTile = Instantiate(tilePrefab, new Vector3(i, j, 0), Quaternion.identity);
                Tiles.Add(currentTile);
                board[i, j] = currentTile.GetComponent<Tile>();
                board[i, j].setX(i);
                board[i, j].setY(j);

            }
        }
    }

    private void Reset()
    {
        foreach(GameObject tile in Tiles)
        {
            Destroy(tile);
        }
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
        board[i, j].setToSnake();
    }

    public Tile[,] GetBoard()
    {
        return board;
    }

    public int GetGridSize()
    {
        return gridSize;
    }
}

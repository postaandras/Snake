using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal;
using static UnityEngine.GraphicsBuffer;


public enum MoveDirection
{
    RIGHT,
    LEFT,
    UP,
    DOWN
}
public class MovementController : MonoBehaviour
{
    private MoveDirection direction = MoveDirection.RIGHT;

    private bool movementCoolDown = false;
    LinkedList<Tile> snaketiles = new LinkedList<Tile>();


    private float snakeSpeed = 0.1f;
    private int stepCount;

    public static MovementController instance;


    public static event EventHandler onGameOver;
    public static event EventHandler<OnApplePick> onApplePick;


    public class OnApplePick : EventArgs
    {
        public float snakeSpeed;
    }

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
        if(!movementCoolDown) {
            StartCoroutine(Move());
        }
        
    }

    IEnumerator Move()
    {
        movementCoolDown = true;
        DetermineSnakeMovement();
        yield return new WaitForSeconds(snakeSpeed);
        movementCoolDown = false;
    }

    private void DetermineSnakeMovement()
    {
        if(snaketiles.Count == 0)
        {
            return;
        }

        Vector2Int currentHead = new((int)snaketiles.First.Value.X, (int)snaketiles.First.Value.Y);
        Tile[,] currentBoard = GridController.instance.GetBoard();

    

        switch(direction)
        {
            case MoveDirection.RIGHT:
                TryToMoveSnake(currentHead.x + 1, currentHead.y, currentBoard);
                break;
            case MoveDirection.LEFT:
                TryToMoveSnake(currentHead.x - 1, currentHead.y, currentBoard);
                break;
            case MoveDirection.UP:
                TryToMoveSnake(currentHead.x, currentHead.y+1, currentBoard);
                break;
            case MoveDirection.DOWN:
                TryToMoveSnake(currentHead.x, currentHead.y-1, currentBoard);
                break;
        }
    }


    public void TryToMoveSnake(int target_x, int target_y, Tile[,] currentBoard)
    {
        if(!IsValid(target_x, target_y, currentBoard))
        {
            GameOver();
            return;        
        }

        Tile nextTile = currentBoard[target_x, target_y];
        MoveSnake(nextTile);
        

    }

    private void MoveSnake(Tile nextTile)
    {
        snaketiles.AddFirst(nextTile);
        stepCount++;

        if (nextTile.IsApple())
        {
            Debug.Log("I eats");
            onApplePick?.Invoke(this, new OnApplePick { snakeSpeed = this.snakeSpeed });
            CollectionController.instance.AppleSpawner(snaketiles);
        }
        else
        {
            snaketiles.Last.Value.SetToField();
            snaketiles.RemoveLast();
        }

        if (stepCount % 2 == 0)
        {
            nextTile.SetToSnake();
        }
        else
        {
            nextTile.SetToDarkSnake();
        }
    }

    private void GameOver()
    {
        snaketiles.Clear();
        stepCount = 0;
        onGameOver?.Invoke(this, EventArgs.Empty);
    }

    

    public bool IsValid(int x, int y, Tile[,] currentBoard)
    {
        int gridSize = GridController.instance.GridSize;
        return (x>=0 &&  y>=0 && x< gridSize && y<gridSize && !snaketiles.Contains(currentBoard[x,y]));
    }

    public void AddToSnake(Tile tile)
    {
        
        snaketiles.AddFirst(tile);
    }

    public LinkedList<Tile> GetSnakeTiles()
    {
        return snaketiles;
    }

    public MoveDirection GetDirection()
    {
        return direction;
    }

    public void SetDirection(MoveDirection direction)
    {
        this.direction = direction;
    }

    public void SetSnakeSpeed(string difficulty)
    {
        switch (difficulty)
        {
            case "hard":
                snakeSpeed = 0.075f;
                break;
            case "medium":
                snakeSpeed = 0.1f;
                break;
            case "easy":
                snakeSpeed = 0.15f;
                break;
        }
    }

 
}

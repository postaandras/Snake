using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Dictionary<KeyCode, MoveDirection> keyMapping;

    public static event EventHandler<OnMove> onMove;
    public class OnMove : EventArgs
    {
        public MoveDirection MoveDirection;
    }

    // Start is called before the first frame update
    void Start()
    {
        keyMapping = new Dictionary<KeyCode, MoveDirection>()
        {
            { KeyCode.W, MoveDirection.UP },
            { KeyCode.S, MoveDirection.DOWN },
            { KeyCode.D, MoveDirection.RIGHT },
            { KeyCode.A, MoveDirection.LEFT }
            // Add more key mappings as needed
        };
    }

    void Update()
    {
        foreach (var kvp in keyMapping)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                if (IsChanging(MovementController.instance.GetDirection(), kvp.Value))
                {
                    MovementController.instance.SetDirection(kvp.Value);
                    onMove?.Invoke(this, new OnMove { MoveDirection = kvp.Value });
                    break;
                }
            }
        }
    }

    public void OnMediumButtonClick()
    {
        Debug.Log("Medium difficulty chosen");
        MovementController.instance.SetSnakeSpeed("medium");
        GridController.instance.InitializeGame();
    }


    public void OnEasyButtonClick()
    {
        Debug.Log("Easy difficulty chosen");
        MovementController.instance.SetSnakeSpeed("easy");
        GridController.instance.InitializeGame();
    }

    public void OnHardButtonClick()
    {
        Debug.Log("Hard difficulty chosen");
        MovementController.instance.SetSnakeSpeed("hard");
        GridController.instance.InitializeGame();
    }

    // Update is called once per frame
    



    private bool IsChanging(MoveDirection current, MoveDirection goal)
    {
        return (current != goal && current != goal.Opposite());
    }
}

public static class Extensions
{
    public static MoveDirection Opposite(this MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.UP: return MoveDirection.DOWN;
            case MoveDirection.DOWN: return MoveDirection.UP;
            case MoveDirection.RIGHT: return MoveDirection.LEFT;
            case MoveDirection.LEFT: return MoveDirection.RIGHT;
            default: return MoveDirection.UP; // Default to prevent compiler error
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(MovementController.instance.GetDirection() != MoveDirection.DOWN)
            {
                MovementController.instance.SetDirection(MoveDirection.UP);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (MovementController.instance.GetDirection() != MoveDirection.UP)
            {
                MovementController.instance.SetDirection(MoveDirection.DOWN);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (MovementController.instance.GetDirection() != MoveDirection.LEFT)
            {
                MovementController.instance.SetDirection(MoveDirection.RIGHT);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (MovementController.instance.GetDirection() != MoveDirection.RIGHT)
            {
                MovementController.instance.SetDirection(MoveDirection.LEFT);
            }
        }
    }
}

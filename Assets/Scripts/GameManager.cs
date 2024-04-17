using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    private void Awake()
    {
        MovementController.onGameOver += MovementController_onGameOver;
    }

    private void OnDestroy()
    {
        MovementController.onGameOver -= MovementController_onGameOver;
    }

    private void MovementController_onGameOver(object sender, System.EventArgs e)
    {
        GameOver();
    }

    public void GameOver()
    {
        PanelController.instance.ShowPanel();

        Debug.Log("Elbasztad");
    }

    public void StartGame()
    {
        GridController.instance.InitializeGame();
    }
}

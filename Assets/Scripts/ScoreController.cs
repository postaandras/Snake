using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MovementController;

public class ScoreController : MonoBehaviour
{
    private void Awake()
    {
        MovementController.onGameOver += MovementController_onGameOver;
        MovementController.onApplePick += MovementController_onApplePick;
    }

    private void OnDestroy()
    {
        MovementController.onGameOver -= MovementController_onGameOver;
        MovementController.onApplePick -= MovementController_onApplePick;
    }


    private void MovementController_onApplePick(object sender, OnApplePick e)
    {
        Debug.Log("Apple picked");
        int currentScore = int.Parse(GetComponent<TextMeshProUGUI>().text);

        float roundedSpeed = Mathf.Round(e.snakeSpeed * 1000f) / 1000f;

        switch (roundedSpeed)
        {
            case 0.1f:
                currentScore += 20;
                break;
            case 0.075f:
                currentScore += 35;
                break;
            case 0.15f:
                currentScore += 10;
                break;
        }

        GetComponent<TextMeshProUGUI>().text = (currentScore).ToString();
    }

    private void MovementController_onGameOver(object sender, System.EventArgs e)
    {
        ResetScore();
    }

    private void ResetScore()
    {
        GetComponent<TextMeshProUGUI>().text = "0";
    }
   
}

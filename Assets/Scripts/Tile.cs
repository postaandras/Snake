using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Tile : MonoBehaviour
{
    [SerializeField] Color snakeColor;
    [SerializeField] Color darkSnakeColor;
    [SerializeField] Color appleColor;
    [SerializeField] Color fieldColor;


    private int X;
    private int Y;

    public void SetX(int x)
    {
        X = x;
    }

    public int GetX()
    {
        return X;
    }

    public void SetY(int y)
    {
        Y = y;
    }

    public int GetY()
    {
        return Y;
    }


    private void Awake()
    {
        SetToField();
    }
    public void SetToSnake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = snakeColor;
    }

    public void SetToDarkSnake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = darkSnakeColor;
    }

    public void SetToApple()
    {
        gameObject.GetComponent<SpriteRenderer>().color = appleColor;
    }

    public void SetToField()
    {
        gameObject.GetComponent<SpriteRenderer>().color = fieldColor;
    }

    public bool IsApple()
    {
        return gameObject.GetComponent<SpriteRenderer>().color == appleColor;
    }
}

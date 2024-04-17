using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Tile : MonoBehaviour
{
    [SerializeField] Color snakeColor;
    [SerializeField] Color darkSnakeColor;
    [SerializeField] Color appleColor;
    [SerializeField] Color fieldColor;

    SpriteRenderer spriteRenderer;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetToField();
    }
    public void SetToSnake()
    {
        spriteRenderer.color = snakeColor;
    }

    public void SetToDarkSnake()
    {
        spriteRenderer.color = darkSnakeColor;
    }

    public void SetToApple()
    {
        spriteRenderer.color = appleColor;
    }

    public void SetToField()
    {
        spriteRenderer.color = fieldColor;
    }

    public bool IsApple()
    {
        return spriteRenderer.color == appleColor;
    }
}

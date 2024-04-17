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

    public int X { get; private set; }
    public int Y { get; private set; }

    public void SetX(int x)
    {
        X = x;
    }

    public void SetY(int y)
    {
        Y = y;
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

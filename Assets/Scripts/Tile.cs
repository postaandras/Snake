using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Tile : MonoBehaviour
{
    [SerializeField] Sprite snakeSprite;
    [SerializeField] Sprite appleSprite;
    [SerializeField] Sprite fieldSprite;

    private int X;
    private int Y;

    public void setX(int x)
    {
        X = x;
    }

    public int getX()
    {
        return X;
    }

    public void setY(int y)
    {
        Y = y;
    }

    public int getY()
    {
        return Y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setToSnake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = snakeSprite;
    }

    public void setToApple()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = appleSprite;
    }

    public void setToField()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = fieldSprite;
    }

    public bool IsApple()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite == appleSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public static CanvasController instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }

    public void HideCanvas()
    {
        this.gameObject.SetActive(false);
    }

     public void ShowCanvas()
    {
        this .gameObject.SetActive(true);
    }
}

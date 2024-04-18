using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    public static PanelController instance;
    // Update is called once per frame
    void Awake()
    {
        instance = this;
    }

    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

     public void ShowPanel()
    {
        this .gameObject.SetActive(true);
    }
}

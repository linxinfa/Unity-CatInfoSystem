using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Canvas canvas;

    void Awake()
    {
        UIManager.Instance.Init(canvas);

    }

    void Start()
    {
        UIManager.Instance.ShowPanel(PanelName.LOGIN_PANEL);
    }

}

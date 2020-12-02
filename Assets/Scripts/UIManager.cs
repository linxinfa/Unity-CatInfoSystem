using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public void Init(Canvas canvas)
    {
        m_canvasTrans = canvas.transform;
    }

    /// <summary>
    /// 显示界面
    /// </summary>
    /// <param name="panelName">界面名称</param>
    /// <returns></returns>
    public GameObject ShowPanel(string panelName)
    {
        GameObject prefabObj = null;
        if (m_panelRes.ContainsKey(panelName))
        {
            prefabObj = m_panelRes[panelName];
        }
        else
        {
            prefabObj = Resources.Load<GameObject>(panelName);
            m_panelRes[panelName] = prefabObj;
        }
        GameObject panelObj = Object.Instantiate(prefabObj);
        panelObj.transform.SetParent(m_canvasTrans, false);
        return panelObj;
    }

    private Transform m_canvasTrans;
    /// <summary>
    /// 界面资源缓存
    /// </summary>
    private Dictionary<string, GameObject> m_panelRes = new Dictionary<string, GameObject>();

    /// <summary>
    /// 单例模式
    /// </summary>
    private static UIManager s_instance;
    public static UIManager Instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new UIManager();
            return s_instance;
        }
    }
}

/// <summary>
/// 界面名称，对应预设文件名称
/// </summary>
public class PanelName
{
    public const string LOGIN_PANEL = "LoginPanel";
    public const string PLAZA_PANEL = "PlazaPanel";
    public const string INFO_PANEL = "InfoPanel";
}
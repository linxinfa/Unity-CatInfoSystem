using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlazaPanel : MonoBehaviour
{

    public Button logoutBtn;
    public Button signBtn;
    public GameObject catItemObj;

    private Transform listRoot;


    void Awake()
    {
        // 注册事件
        EventDispatcher.instance.Regist(EventNameDef.EVENT_ADD_OR_MODIFY_CAT, OnEventAddOrModifyCat);
        EventDispatcher.instance.Regist(EventNameDef.EVENT_DEL_CAT, OnEventDelCat);

        CatManager.Instance.Init();
        catItemObj.SetActive(false);
        listRoot = catItemObj.transform.parent;
    }

    void Start()
    {
        // 退出登录
        logoutBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
            UIManager.Instance.ShowPanel(PanelName.LOGIN_PANEL);
        });

        // 登记新信息
        signBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel(PanelName.INFO_PANEL);
        });

        // 遍历数据，创建列表
        foreach (CatInfo catInfo in CatManager.Instance.data.Values)
        {
            CreateItem(catInfo);
        }

    }

    /// <summary>
    /// 创建信息列表的一行ui
    /// </summary>
    /// <param name="info"></param>
    void CreateItem(CatInfo info)
    {
        var obj = Instantiate(catItemObj);
        obj.SetActive(true);
        obj.transform.SetParent(listRoot, false);
        var itemUi = obj.GetComponent<CatListItem>();
        // 使用数据更新ui
        itemUi.UpdateUi(info);
        // 缓存，方便后面更新ui
        m_catUiList[info.uuid] = itemUi;
    }

    /// <summary>
    /// 数据发生变化，更新ui
    /// </summary>
    /// <param name="args"></param>
    void OnEventAddOrModifyCat(params object[] args)
    {
        var info = args[0] as CatInfo;
        if (m_catUiList.ContainsKey(info.uuid))
        {
            m_catUiList[info.uuid].UpdateUi(info);
        }
        else
        {
            // 创建多一行
            CreateItem(info);
        }
    }

    /// <summary>
    /// 信息被删除，删除对应的ui
    /// </summary>
    /// <param name="args"></param>
    void OnEventDelCat(params object[] args)
    {
        var uuid = (string)args[0];
        if (m_catUiList.ContainsKey(uuid))
        {
            var ui = m_catUiList[uuid];
            if(null != ui)
            {
                Destroy(ui.gameObject);
            }
            m_catUiList.Remove(uuid);
        }

    }

    /// <summary>
    /// 界面被销毁
    /// </summary>
    private void OnDestroy()
    {
        // 注销事件
        EventDispatcher.instance.UnRegist(EventNameDef.EVENT_ADD_OR_MODIFY_CAT, OnEventAddOrModifyCat);
        EventDispatcher.instance.UnRegist(EventNameDef.EVENT_DEL_CAT, OnEventDelCat);
    }

    private Dictionary<string, CatListItem> m_catUiList = new Dictionary<string, CatListItem>();
}

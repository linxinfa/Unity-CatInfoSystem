using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager
{
    public void Init()
    {
        // 从数据库加载数据
        m_datas = CatDataBase.QueryDatas();
    }

    /// <summary>
    /// 新增或修改猫信息
    /// </summary>
    /// <param name="info"></param>
    public void AddOrModify(CatInfo info)
    {
        CatDataBase.AddOrModify(info);
        // 抛出事件，更新界面
        EventDispatcher.instance.DispatchEvent(EventNameDef.EVENT_ADD_OR_MODIFY_CAT, info);
    }

    /// <summary>
    /// 删除猫信息
    /// </summary>
    /// <param name="uuid"></param>
    public void Del(string uuid)
    {
        CatDataBase.Del(uuid);
        // 抛出事件，更新界面
        EventDispatcher.instance.DispatchEvent(EventNameDef.EVENT_DEL_CAT, uuid);
    }

    public Dictionary<string, CatInfo> data
    {
        get { return m_datas; }
    }

    /// <summary>
    /// 猫信息数据缓存
    /// </summary>
    private Dictionary<string, CatInfo> m_datas = null;

    /// <summary>
    /// 单例模式
    /// </summary>
    private static CatManager s_instance;
    public static CatManager Instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new CatManager();
            return s_instance;
        }
    }
}

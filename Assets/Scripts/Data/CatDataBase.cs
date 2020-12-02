using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

/// <summary>
/// 猫数据库
/// </summary>
public class CatDataBase
{

    /// <summary>
    /// 新增或修改数据
    /// </summary>
    /// <param name="info"></param>
    public static void AddOrModify(CatInfo info)
    {
        if (s_datas.ContainsKey(info.uuid))
        {
            s_datas[info.uuid] = info;
        }
        else
        {
            s_datas.Add(info.uuid, info);
        }
        
        SaveData();
    }

    /// <summary>
    /// 删数据
    /// </summary>
    /// <param name="uuid"></param>
    public static void Del(string uuid)
    {
        if (!s_datas.ContainsKey(uuid)) return;
        s_datas.Remove(uuid);
        SaveData();
    }

    /// <summary>
    /// 查询所有猫信息
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, CatInfo> QueryDatas()
    {
        string jsonStr = PlayerPrefs.GetString("cats", null);
        if (string.IsNullOrEmpty(jsonStr))
        {
            s_datas = new Dictionary<string, CatInfo>();
        }
        else
        {
            s_datas = JsonMapper.ToObject<Dictionary<string, CatInfo>>(jsonStr);
        }
        return s_datas;
    }

    /// <summary>
    /// 使用PlayerPrefs将数据写入本地
    /// </summary>
    public static void SaveData()
    {
        string jsonStr = JsonMapper.ToJson(s_datas);
        PlayerPrefs.SetString("cats", jsonStr);
    }

    private static Dictionary<string, CatInfo> s_datas = new Dictionary<string, CatInfo>();
}

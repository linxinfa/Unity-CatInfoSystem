/// <summary>
/// 猫咪信息
/// </summary>
public class CatInfo 
{
    public CatInfo()
    {
        uuid = System.Guid.NewGuid().ToString("N");
    }


    /// <summary>
    /// 系统唯一标识符
    /// </summary>
    public string uuid;
    /// <summary>
    /// 喵星身份编号
    /// </summary>
    public string id;
    /// <summary>
    /// 昵称
    /// </summary>
    public string nickname;
    /// <summary>
    /// 品种
    /// </summary>
    public string kind;
    /// <summary>
    /// 毛色
    /// </summary>
    public string color;
    /// <summary>
    /// 性别，0：母，1：公
    /// </summary>
    public int gender;
    /// <summary>
    /// 出生
    /// </summary>
    public string birth;
    /// <summary>
    /// 流浪原因
    /// </summary>
    public string reason;
}

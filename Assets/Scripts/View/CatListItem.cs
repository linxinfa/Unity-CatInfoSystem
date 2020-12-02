using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 列表的一行ui
/// </summary>
public class CatListItem : MonoBehaviour
{
    public Text idText;
    public Text nameText;
    public Text kindText;
    public Text colorText;
    public Text genderText;
    public Text birthText;
    public Text resonText;

    public Button itemBtn;

    public void Start()
    {
        // 列表的行被点击，打开信息界面
        itemBtn.onClick.AddListener(() => 
        {
            var panelObj =  UIManager.Instance.ShowPanel(PanelName.INFO_PANEL);
            var infoPanel = panelObj.GetComponent<InfoPanel>();
            infoPanel.Init(m_info);
        });
    }

    /// <summary>
    /// 更新ui
    /// </summary>
    /// <param name="info"></param>
    public void UpdateUi(CatInfo info)
    {
        m_info = info;
        idText.text = info.id;
        nameText.text = info.nickname;
        kindText.text = info.kind;
        colorText.text = info.color;
        genderText.text = 0 == info.gender ? "母" : "公";
        birthText.text = info.birth;
        resonText.text = info.reason;
    }

    private CatInfo m_info;
}

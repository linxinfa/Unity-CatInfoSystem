using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public InputField idInput;
    public InputField kindInput;
    public InputField nameInput;
    public InputField colorInput;
    public Dropdown genderDropdown;
    public InputField birthInput;
    public InputField reasonInput;

    public Button okBtn;
    public Button delBtn;
    public Button closeBtn;

    public CatInfo m_catInfo;

    public void Init(CatInfo info)
    {
        m_catInfo = info;
        idInput.text = info.id;
        kindInput.text = info.kind;
        nameInput.text = info.nickname;
        colorInput.text = info.color;
        genderDropdown.value = info.gender;
        birthInput.text = info.birth;
        reasonInput.text = info.reason;
    }

    private CatInfo MakeCatInfo()
    {
        if (null == m_catInfo)
            m_catInfo = new CatInfo();
        m_catInfo.id = idInput.text;
        m_catInfo.kind = kindInput.text;
        m_catInfo.nickname = nameInput.text;
        m_catInfo.color = colorInput.text;
        m_catInfo.gender = genderDropdown.value;
        m_catInfo.birth = birthInput.text;
        m_catInfo.reason = reasonInput.text;
        return m_catInfo;
    }

    void Start()
    {
        okBtn.onClick.AddListener(() =>
        {
            // 新增或修改
            CatManager.Instance.AddOrModify(MakeCatInfo());
            Destroy(gameObject);

        });
        delBtn.onClick.AddListener(() =>
        {
            // 删除
            if(null != m_catInfo)
            {
                CatManager.Instance.Del(m_catInfo.uuid);
            }
            
            Destroy(gameObject);
        });

        closeBtn.onClick.AddListener(() => 
        {
            Destroy(gameObject);
        });
    }
}

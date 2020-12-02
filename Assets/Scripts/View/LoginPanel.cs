using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    public InputField nameInput;
    public InputField pwdInput;

    public Button loginBtn;

    void Start()
    {
        loginBtn.onClick.AddListener(() =>
        {
            if ("admin" == nameInput.text && "123456" == pwdInput.text)
            {
                Destroy(gameObject);
                UIManager.Instance.ShowPanel(PanelName.PLAZA_PANEL);
            }
        });
    }
}

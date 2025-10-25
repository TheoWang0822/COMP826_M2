using UnityEngine;
using UnityEngine.UI;

public class OverviewView : MonoBehaviour
{
    public Button sideBtn;
    public SideMenuView sideMenu;
    void Start()
    {
        if (sideBtn != null)
        {
            sideBtn.onClick.AddListener(OnHamburgerClick);
        }
        else
        {
            Debug.LogError("SideBtn unassigned！");
        }
    }

    // 汉堡按钮点击回调函数
    private void OnHamburgerClick()
    {
        if (sideMenu != null)
        {
            sideMenu.ToggleMenu();
            UIController.Instance.ShowPanel(UIController.Instance.sideMenuPanel);
        }
        else
        {
            Debug.LogError("SideMenuView not found！");
        }
    }
}

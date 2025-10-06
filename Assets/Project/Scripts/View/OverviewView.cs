using UnityEngine;
using UnityEngine.UI;

public class OverviewView : MonoBehaviour
{
    public Button sideBtn;
    private SideMenuView sideMenu;
    void Start()
    {
        sideMenu = FindObjectOfType<SideMenuView>();
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
            sideMenu.ToggleMenu(); // 调用打开/关闭侧菜单
        }
        else
        {
            Debug.LogError("SideMenuView not found！");
        }
    }
}

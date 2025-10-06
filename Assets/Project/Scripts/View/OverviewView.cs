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
            Debug.LogError("SideBtn unassigned��");
        }
    }

    // ������ť����ص�����
    private void OnHamburgerClick()
    {
        if (sideMenu != null)
        {
            sideMenu.ToggleMenu(); // ���ô�/�رղ�˵�
        }
        else
        {
            Debug.LogError("SideMenuView not found��");
        }
    }
}

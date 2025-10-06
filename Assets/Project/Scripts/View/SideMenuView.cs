using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SideMenuView : MonoBehaviour
{
    public RectTransform sideMenuRect; // 拖拽SideMenuPanel的RectTransform
    public Button ExitBtn;
    public float slideDuration = 0.3f; // 动画时长
    private float menuWidth= 800f; // 菜单宽度
    private bool isOpen = false;
    //private GameObject isSliding = false;

    void Start()
    {
        sideMenuRect.anchoredPosition = new Vector2(-menuWidth, 0); // 初始隐藏在左侧
        ExitBtn.onClick.AddListener(CloseMenu);
    }

    // ToggleMenu函数：切换菜单状态（核心逻辑）
    public void ToggleMenu()
    {
        if (isOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    // 打开菜单的辅助函数
    private void OpenMenu()
    {
        sideMenuRect.DOAnchorPosX(0, slideDuration).SetEase(Ease.OutCubic); // 从左滑入
        isOpen = true;
        ExitBtn.gameObject.SetActive(true);
    }

    // 关闭菜单的辅助函数
    private void CloseMenu()
    {
        sideMenuRect.DOAnchorPosX(-menuWidth, slideDuration).SetEase(Ease.InCubic); // 向左滑出
        isOpen = false;
        ExitBtn.gameObject.SetActive(false);
    }
}

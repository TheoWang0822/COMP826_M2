using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SideMenuView : MonoBehaviour
{
    public Button SearchBtn;
    public Button fighterListBtn;
    public Button taskListBtn;


    public RectTransform sideMenuRect;
    public Button ExitBtn;
    public float slideDuration = 0.3f;
    private float menuWidth= 800f; //
    private bool isOpen = false;

    void OnEnable()
    {
        isOpen = false;
        sideMenuRect.anchoredPosition = new Vector2(-menuWidth, 0);
        ExitBtn.onClick.AddListener(CloseMenu);

        if (fighterListBtn != null)
        {
            fighterListBtn.onClick.AddListener(OnFighterListClick);
        }
        else
        {
            Debug.LogError("fighterListBtn unassigned£¡");
        }

        if (SearchBtn != null)
        {
            SearchBtn.onClick.AddListener(OnSearchClick);
        }
        else
        {
            Debug.LogError("SearchBtn unassigned£¡");
        }

        if (taskListBtn != null)
        {
            taskListBtn.onClick.AddListener(OnTasksClick);
        }
        else
        {
            Debug.LogError("taskListBtn unassigned£¡");
        }
    }
    public void ToggleMenu()
    {
        Debug.Log("overhere2 " + isOpen);
        if (isOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        sideMenuRect.DOAnchorPosX(0, slideDuration).SetEase(Ease.OutCubic); // ´Ó×ó»¬Èë
        isOpen = true;
        ExitBtn.gameObject.SetActive(true);
    }
    private void CloseMenu()
    {
        sideMenuRect.DOAnchorPosX(-menuWidth, slideDuration).SetEase(Ease.InCubic).OnComplete(() => {
            isOpen = false;
            ExitBtn.gameObject.SetActive(false);
            UIController.Instance.Back();
        });
    }

    private void OnSearchClick()
    {
        UIController.Instance.ClearStack();
        //sideMenuRect.anchoredPosition = new Vector2(-menuWidth, 0);
    }

    private void OnFighterListClick()
    {
        UIController.Instance.ShowPanel(UIController.Instance.FireFighterListMenuPanel);
        //sideMenuRect.anchoredPosition = new Vector2(-menuWidth, 0);
    }

    private void OnTasksClick()
    {
        UIController.Instance.ShowPanel(UIController.Instance.TaskListMenuPanel);
    }
}

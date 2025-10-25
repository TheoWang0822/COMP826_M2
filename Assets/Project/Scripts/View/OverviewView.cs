using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class OverviewView : MonoBehaviour
{
    public Button sideBtn;
    public SideMenuView sideMenu;
    [SerializeField] private TMP_InputField searchInput;
    [SerializeField] private Button searchButton;
    [SerializeField] private TextMeshProUGUI notFoundText;
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
        searchButton.onClick.AddListener(OnSearch);
        notFoundText.gameObject.SetActive(false);
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



    private void OnSearch()
    {
        string query = searchInput.text.Trim().ToLower();
        if (string.IsNullOrEmpty(query))
        {
            Debug.Log("Search query is empty");
            return;
        }
        FireFighterListSO fighterData = UIController.Instance.GetFirefighterData();

        FireFighterListSO.Firefighter foundFighter = null;
        foreach (var fighter in fighterData.firefighters)
        {
            if (fighter.name.ToLower() == query)
            {
                foundFighter = fighter;
                break;
            }
        }

        if (foundFighter != null)
        {
            UIController.Instance.ShowPanel(UIController.Instance.FighterDetailPanel);
            FighterDetailPanel detailView = FindObjectOfType<FighterDetailPanel>();
            if (detailView != null)
            {
                detailView.SetId(foundFighter.id);
            }
        }
        else
        {
            ShowNotFound("Firefighter not found");
        }
    }

    private void ShowNotFound(string message)
    {
        notFoundText.text = message;
        notFoundText.gameObject.SetActive(true);
        Vector3 originalPos = notFoundText.transform.localPosition;
        notFoundText.transform.DOLocalMoveY(originalPos.y + 50f, 1f).SetEase(Ease.OutSine);
        notFoundText.DOFade(0f, 1f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            notFoundText.gameObject.SetActive(false);
            notFoundText.alpha = 1f;
            notFoundText.transform.localPosition = originalPos;
        });
    }
}

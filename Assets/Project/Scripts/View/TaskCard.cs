using UnityEngine;
using TMPro; // ”√”⁄TMP_Text
using UnityEngine.UI;

public class TaskCard : MonoBehaviour
{
    public TMP_Text taskDesc;
    public TMP_Text taskStatus;
    public TMP_Text taskAssignee;
    public Button btn;
    private string id;

    void Start() {
        id = "11";
        if (btn != null)
        {
            btn.onClick.AddListener(OnBtnClick);
        }
    }
    public void UpdateCard(string desc, string status, string assignee)
    {
        if (taskDesc != null) taskDesc.text = desc;
        if (taskStatus != null) taskStatus.text = status;
        if (taskAssignee != null) taskAssignee.text = assignee;
    }
    void OnBtnClick() {
        UIController.Instance.ShowPanel(UIController.Instance.TaskAssignPanel);
    }
}
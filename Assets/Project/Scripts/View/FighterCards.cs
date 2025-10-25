using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FighterCards : MonoBehaviour
{
    public Image userIcon;
    public Image userShade;
    public TMP_Text userName;
    public TMP_Text userId;
    public TMP_Text userStatus;
    public Button cardButton;

    private string var_userName;
    private string var_userId;
    private string var_userStatus;

    void Start()
    {
        if (cardButton != null)
        {
            cardButton.onClick.AddListener(OnCardClick);
        }
    }


    public void UpdateCard(string id, string name, string status)
    {
        if (userId != null) { 
            //userId.text = id;
            var_userId = id;
        }
        var_userId = id;
        if (userName != null) { 
            userName.text = name;
            var_userName = name;
        }
        if (userStatus != null) { 
            userStatus.text = status;
            var_userStatus = status;
        }
    }

    // �����Ƭ: ��ʾ����ҳ
    private void OnCardClick()
    {
        string id = var_userId; // ��ȡ��ǰ��ƬID
        /*FighterDetailPanel detailView = FindObjectOfType<FighterDetailPanel>();
        if (detailView != null)
        {
            detailView.SetId(id);
        }*/
        UIController.Instance.ShowPanel(UIController.Instance.FighterDetailPanel);
        FighterDetailPanel detailView = FindObjectOfType<FighterDetailPanel>();
        if (detailView != null)
        {
            detailView.SetId(id);
        }
    }
}
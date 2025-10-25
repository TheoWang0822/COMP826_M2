using UnityEngine;
using UnityEngine.UI; // ����Text, Image
using System.Collections.Generic; // ����List

public class FirefighterListPanel : MonoBehaviour
{
    //[SerializeField]
    private FireFighterListSO firefighterData; // ��קSO�ʲ�
    public List<GameObject> cardList = new List<GameObject>(); // ��ק�ĸ�FighterCardsʵ�����б� (Hierarchy˳��)
    public Button ExitBtn;

    void OnEnable()
    { // �����ʾʱˢ��
        firefighterData = UIController.Instance.GetFirefighterData();
        RefreshList();
        /*firefighterData = UIController.Instance.GetFirefighterData();*/
        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(OnExitClick);
        }
        else
        {
            Debug.LogError("ExitBtn unassigned��");
        }
    }

    void OnDisable()
    {
        if (ExitBtn != null)
        {
            ExitBtn.onClick.RemoveListener(OnExitClick); // �Ƴ�����
        }
    }


    private void RefreshList()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            if (i >= firefighterData.firefighters.Count)
            {
                cardList[i].SetActive(false); // �����������4�����ض��࿨Ƭ
                continue;
            }

            var ff = firefighterData.firefighters[i]; // ��ȡ����
            GameObject card = cardList[i];

            // һ��һ����ֵ (����ÿ����Ƭ��FighterCards�ű�)
            FighterCards cardScript = card.GetComponent<FighterCards>();
            if (cardScript != null)
            {
                cardScript.UpdateCard(ff.id, ff.name, ff.status);
            }
            else
            {
                // ����޽ű���ֱ��GetComponent��ֵ
                Text userName = card.transform.Find("UserName").GetComponent<Text>();
                if (userName != null) userName.text = ff.name;

                Text userId = card.transform.Find("UserId").GetComponent<Text>(); // �����ID Text
                if (userId != null) userId.text = ff.id;

                Text userStatus = card.transform.Find("UserStatus").GetComponent<Text>(); // �����Status Text
                if (userStatus != null) userStatus.text = ff.status;

                // ͼ��: userIcon.sprite = ... (ģ����Ĭ��)
            }
            card.SetActive(true);
        }
    }

    private void OnExitClick()
    {
        UIController.Instance.ClearStack();
    }
}
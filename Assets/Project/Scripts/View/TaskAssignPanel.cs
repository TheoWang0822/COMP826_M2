using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TaskAssignPanel : MonoBehaviour
{

    public List<GameObject> cardList = new List<GameObject>(); // ��ק�̶�����Ա��Ƭ (FighterCardsԤ����ʵ��, Size=4)
    public Button exitBtn;

    void OnEnable()
    {
        RefreshAssignmentList();
        if (exitBtn != null)
        {
            exitBtn.onClick.AddListener(OnExitClick);
        }
    }

    private void RefreshAssignmentList()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            if (i >= UIController.Instance.GetFirefighterData().firefighters.Count)
            {
                cardList[i].SetActive(false); // ���ݲ���4�����ض���
                continue;
            }

            var ff = UIController.Instance.GetFirefighterData().firefighters[i]; // ��SO�ϸ������

            FighterCards cardScript = cardList[i].GetComponent<FighterCards>();
            if (cardScript != null)
            {
                cardScript.UpdateCard(ff.id, ff.name, ff.status);
            }
            cardList[i].SetActive(true);
        }
    }

    private void OnExitClick()
    {
        UIController.Instance.Back(); // ����ҳ��
    }
}

using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TaskAssignPanel : MonoBehaviour
{

    public List<GameObject> cardList = new List<GameObject>(); // 拖拽固定消防员卡片 (FighterCards预制体实例, Size=4)
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
                cardList[i].SetActive(false); // 数据不足4，隐藏多余
                continue;
            }

            var ff = UIController.Instance.GetFirefighterData().firefighters[i]; // 从SO严格读数据

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
        UIController.Instance.Back(); // 回退页面
    }
}

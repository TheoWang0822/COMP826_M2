using UnityEngine;
using UnityEngine.UI; // 用于Text, Image
using System.Collections.Generic; // 用于List

public class FirefighterListPanel : MonoBehaviour
{
    //[SerializeField]
    private FireFighterListSO firefighterData; // 拖拽SO资产
    public List<GameObject> cardList = new List<GameObject>(); // 拖拽四个FighterCards实例到列表 (Hierarchy顺序)
    public Button ExitBtn;

    void OnEnable()
    { // 面板显示时刷新
        firefighterData = UIController.Instance.GetFirefighterData();
        RefreshList();
        /*firefighterData = UIController.Instance.GetFirefighterData();*/
        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(OnExitClick);
        }
        else
        {
            Debug.LogError("ExitBtn unassigned！");
        }
    }

    void OnDisable()
    {
        if (ExitBtn != null)
        {
            ExitBtn.onClick.RemoveListener(OnExitClick); // 移除监听
        }
    }


    private void RefreshList()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            if (i >= firefighterData.firefighters.Count)
            {
                cardList[i].SetActive(false); // 如果数据少于4，隐藏多余卡片
                continue;
            }

            var ff = firefighterData.firefighters[i]; // 获取数据
            GameObject card = cardList[i];

            // 一个一个赋值 (假设每个卡片有FighterCards脚本)
            FighterCards cardScript = card.GetComponent<FighterCards>();
            if (cardScript != null)
            {
                cardScript.UpdateCard(ff.id, ff.name, ff.status);
            }
            else
            {
                // 如果无脚本，直接GetComponent赋值
                Text userName = card.transform.Find("UserName").GetComponent<Text>();
                if (userName != null) userName.text = ff.name;

                Text userId = card.transform.Find("UserId").GetComponent<Text>(); // 如果有ID Text
                if (userId != null) userId.text = ff.id;

                Text userStatus = card.transform.Find("UserStatus").GetComponent<Text>(); // 如果有Status Text
                if (userStatus != null) userStatus.text = ff.status;

                // 图标: userIcon.sprite = ... (模拟用默认)
            }
            card.SetActive(true);
        }
    }

    private void OnExitClick()
    {
        UIController.Instance.ClearStack();
    }
}
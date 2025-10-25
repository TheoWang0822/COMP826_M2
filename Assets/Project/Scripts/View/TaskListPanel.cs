using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TaskListPanel : MonoBehaviour
{
    public List<GameObject> cardList = new List<GameObject>(); // 拖拽三个任务卡片到列表 (Size=3)
    public Button ExitBtn;
    private TaskListSO taskData;

    void OnEnable()
    {
        taskData = UIController.Instance.GetTaskData();
        RefreshTasks();

        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(OnExitClick);
        }
        else
        {
            Debug.LogError("ExitBtn unassigned！");
        }
    }

    private void RefreshTasks()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            if (i >= taskData.tasks.Count)
            {
                cardList[i].SetActive(false); // 数据不足3，隐藏多余
                continue;
            }

            var task = taskData.tasks[i]; // 获取数据

            TaskCard cardScript = cardList[i].GetComponent<TaskCard>();
            if (cardScript != null)
            {
                cardScript.UpdateCard(task.description, task.status, task.assignee);
            }
            cardList[i].SetActive(true);
        }
    }

    private void OnExitClick()
    {
        UIController.Instance.ClearStack();
    }
}

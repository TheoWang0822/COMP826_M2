using UnityEngine;
using TMPro; // 用于TMP_Text
using UnityEngine.UI; // 用于Button
using System.Collections.Generic;

public class FighterTaskPanel : MonoBehaviour
{
    // TMP_Text引用：拖拽Hierarchy元素
    public TMP_Text idTxt; // IdTxt
    public TMP_Text nameTxt; // NameTxt
    public TMP_Text floorTxt; // Floor Text
    public TMP_Text statusTxt; // Status Text
    public TMP_Text coordinateTxt; // Coordinate Text
    public TMP_Text taskTxt; // Task Text (当前任务)

    // 右侧Task列表引用：拖拽三个TaskTxt
    public List<TMP_Text> taskListTexts = new List<TMP_Text>(); // Size=3, 拖拽TaskTxt, (1), (2)

    // Task容器：拖拽TaskContainer
    public GameObject taskContainer;

    // Button引用：拖拽
    public Button exitBtn; // ExitBtn

    private string currentId; // 当前ID

    void OnEnable()
    {
        if (exitBtn != null)
        {
            exitBtn.onClick.AddListener(OnExitClick);
        }
    }

    void OnDisable()
    {
        if (exitBtn != null)
        {
            exitBtn.onClick.RemoveListener(OnExitClick);
        }
    }

    public void SetId(string id)
    {
        currentId = id;
        LoadData();
    }

    private void LoadData()
    {
        // 从FirefighterListSO严格读匹配ID的数据
        FireFighterListSO.Firefighter ff = null;
        foreach (var fighter in UIController.Instance.GetFirefighterData().firefighters)
        {
            if (fighter.id == currentId)
            {
                ff = fighter;
                break;
            }
        }
        if (ff == null)
        {
            return;
        }

        // 更新左侧数据
        if (idTxt != null) { 
            idTxt.text = ff.id;
        }
        if (nameTxt != null) nameTxt.text = ff.name;
        if (statusTxt != null) statusTxt.text = ff.status;
        if (coordinateTxt != null) coordinateTxt.text = ff.location.ToString("F2");
        if (floorTxt != null) floorTxt.text = Mathf.FloorToInt(ff.location.y).ToString();
        if (taskTxt != null) taskTxt.text = ff.task;

        // 检查状态: 如果不是"Busy"，显示右侧TaskContainer，并从TaskListSO严格读所有tasks赋值
        if (taskContainer != null)
        {
            if (ff.status != "Busy")
            {
                taskContainer.SetActive(true);
                LoadAllTasks();
            }
            else
            {
                taskContainer.SetActive(false);
            }
        }
    }

    private void LoadAllTasks()
    {
        // 从TaskListSO严格读所有tasks (写死三个)，循环赋值到三个TMP_Text
        for (int i = 0; i < taskListTexts.Count; i++)
        {
            if (i >= UIController.Instance.GetTaskData().tasks.Count)
            {
                taskListTexts[i].gameObject.SetActive(false);
                continue;
            }

            var task = UIController.Instance.GetTaskData().tasks[i];
            if (taskListTexts[i] != null)
            {
                taskListTexts[i].text = task.description; // 或完整显示: task.description + " (" + task.status + ", Assignee: " + task.assigneeId + ")"
            }
            taskListTexts[i].gameObject.SetActive(true);
        }
    }

    private void OnExitClick()
    {
        UIController.Instance.Back();
    }
}

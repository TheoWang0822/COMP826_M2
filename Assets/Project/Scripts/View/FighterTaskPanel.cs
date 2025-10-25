using UnityEngine;
using TMPro; // ����TMP_Text
using UnityEngine.UI; // ����Button
using System.Collections.Generic;

public class FighterTaskPanel : MonoBehaviour
{
    // TMP_Text���ã���קHierarchyԪ��
    public TMP_Text idTxt; // IdTxt
    public TMP_Text nameTxt; // NameTxt
    public TMP_Text floorTxt; // Floor Text
    public TMP_Text statusTxt; // Status Text
    public TMP_Text coordinateTxt; // Coordinate Text
    public TMP_Text taskTxt; // Task Text (��ǰ����)

    // �Ҳ�Task�б����ã���ק����TaskTxt
    public List<TMP_Text> taskListTexts = new List<TMP_Text>(); // Size=3, ��קTaskTxt, (1), (2)

    // Task��������קTaskContainer
    public GameObject taskContainer;

    // Button���ã���ק
    public Button exitBtn; // ExitBtn

    private string currentId; // ��ǰID

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
        // ��FirefighterListSO�ϸ��ƥ��ID������
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

        // �����������
        if (idTxt != null) { 
            idTxt.text = ff.id;
        }
        if (nameTxt != null) nameTxt.text = ff.name;
        if (statusTxt != null) statusTxt.text = ff.status;
        if (coordinateTxt != null) coordinateTxt.text = ff.location.ToString("F2");
        if (floorTxt != null) floorTxt.text = Mathf.FloorToInt(ff.location.y).ToString();
        if (taskTxt != null) taskTxt.text = ff.task;

        // ���״̬: �������"Busy"����ʾ�Ҳ�TaskContainer������TaskListSO�ϸ������tasks��ֵ
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
        // ��TaskListSO�ϸ������tasks (д������)��ѭ����ֵ������TMP_Text
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
                taskListTexts[i].text = task.description; // ��������ʾ: task.description + " (" + task.status + ", Assignee: " + task.assigneeId + ")"
            }
            taskListTexts[i].gameObject.SetActive(true);
        }
    }

    private void OnExitClick()
    {
        UIController.Instance.Back();
    }
}

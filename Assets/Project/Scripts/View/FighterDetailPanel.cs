using UnityEngine;
using TMPro; // 用于TMP_Text
using UnityEngine.UI; // 用于Button
using System.Collections.Generic;

public class FighterDetailPanel : MonoBehaviour
{

    // TMP_Text引用：拖拽UI元素
    public TMP_Text idTxt; // IdTxt (ID显示)
    public TMP_Text nameTxt; // NameTxt (Name显示)
    public TMP_Text floorTxt; // Floor Text (Floor显示, 从Location.Y推算)
    public TMP_Text statusTxt; // Status Text (Status显示)
    public TMP_Text coordinateTxt; // Coordinate Text (Location XYZ显示)
    public TMP_Text taskTxt; // Task Text (Task显示)

    // Button引用：拖拽
    public Button evacuateBtn; // Evacuate按钮
    public Button TaskBtn; // Task
    public Button exitBtn; // ExitBtn (关闭按钮)

    // 临时ID (从列表点击传, 这里假设固定取第一个消防员; 实际用SetId(string id)传)
    private string currentId = "11"; // 示例ID, 匹配SO第一个 (James)

    void OnEnable()
    {
        LoadData(); // 面板显示时加载数据
        if (exitBtn != null)
        {
            exitBtn.onClick.AddListener(OnExitClick);
        }
        if (evacuateBtn != null)
        {
            evacuateBtn.onClick.AddListener(OnEvacuateClick);
        }
        if (TaskBtn != null)
        {
            TaskBtn.onClick.AddListener(OnTaskClick);
        }
    }

    void OnDisable()
    {
        if (exitBtn != null)
        {
            exitBtn.onClick.RemoveListener(OnExitClick);
        }
        if (evacuateBtn != null)
        {
            evacuateBtn.onClick.RemoveListener(OnEvacuateClick);
        }
        if (TaskBtn != null)
        {
            TaskBtn.onClick.RemoveListener(OnTaskClick);
        }
    }

    private void LoadData()
    {
        // 从SO取匹配ID的消防员数据 (循环找, 或用LINQ)
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

        // 更新TMP_Text
        if (idTxt != null) idTxt.text = ff.id;
        if (nameTxt != null) nameTxt.text = ff.name;
        if (statusTxt != null) statusTxt.text = ff.status;
        if (taskTxt != null) taskTxt.text = ff.task;
        if (coordinateTxt != null) coordinateTxt.text = ff.location.ToString(); // XYZ格式
        if (floorTxt != null) floorTxt.text = Mathf.FloorToInt(ff.location.y).ToString(); // 从Y坐标推算楼层 (假设Y=0为1楼)
    }

    private void OnExitClick()
    {
        UIController.Instance.Back(); // 回退页面
    }

    private void OnEvacuateClick()
    {
        // Evacuate逻辑: e.g., 更新状态为"Evacuating", 或调用NavMesh路径
        Debug.Log("Evacuate for ID: " + currentId);
        // 可更新SO或调用API
    }

    private void OnTaskClick()
    {
        UIController.Instance.ShowPanel(UIController.Instance.FighterTaskPanel);

        FighterTaskPanel FTView = FindObjectOfType<FighterTaskPanel>();
        if (FTView != null)
        {
            FTView.SetId(currentId);
        }
    }

    // 可选: 从列表点击传ID
    public void SetId(string id)
    {
        currentId = id;
        LoadData(); // 立即刷新
    }
}

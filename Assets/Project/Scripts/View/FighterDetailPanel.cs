using UnityEngine;
using TMPro; // ����TMP_Text
using UnityEngine.UI; // ����Button
using System.Collections.Generic;

public class FighterDetailPanel : MonoBehaviour
{

    // TMP_Text���ã���קUIԪ��
    public TMP_Text idTxt; // IdTxt (ID��ʾ)
    public TMP_Text nameTxt; // NameTxt (Name��ʾ)
    public TMP_Text floorTxt; // Floor Text (Floor��ʾ, ��Location.Y����)
    public TMP_Text statusTxt; // Status Text (Status��ʾ)
    public TMP_Text coordinateTxt; // Coordinate Text (Location XYZ��ʾ)
    public TMP_Text taskTxt; // Task Text (Task��ʾ)

    // Button���ã���ק
    public Button evacuateBtn; // Evacuate��ť
    public Button TaskBtn; // Task
    public Button exitBtn; // ExitBtn (�رհ�ť)

    // ��ʱID (���б�����, �������̶�ȡ��һ������Ա; ʵ����SetId(string id)��)
    private string currentId = "11"; // ʾ��ID, ƥ��SO��һ�� (James)

    void OnEnable()
    {
        LoadData(); // �����ʾʱ��������
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
        // ��SOȡƥ��ID������Ա���� (ѭ����, ����LINQ)
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

        // ����TMP_Text
        if (idTxt != null) idTxt.text = ff.id;
        if (nameTxt != null) nameTxt.text = ff.name;
        if (statusTxt != null) statusTxt.text = ff.status;
        if (taskTxt != null) taskTxt.text = ff.task;
        if (coordinateTxt != null) coordinateTxt.text = ff.location.ToString(); // XYZ��ʽ
        if (floorTxt != null) floorTxt.text = Mathf.FloorToInt(ff.location.y).ToString(); // ��Y��������¥�� (����Y=0Ϊ1¥)
    }

    private void OnExitClick()
    {
        UIController.Instance.Back(); // ����ҳ��
    }

    private void OnEvacuateClick()
    {
        // Evacuate�߼�: e.g., ����״̬Ϊ"Evacuating", �����NavMesh·��
        Debug.Log("Evacuate for ID: " + currentId);
        // �ɸ���SO�����API
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

    // ��ѡ: ���б�����ID
    public void SetId(string id)
    {
        currentId = id;
        LoadData(); // ����ˢ��
    }
}

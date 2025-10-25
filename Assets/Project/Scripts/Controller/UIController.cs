using UnityEngine;
using System.Collections.Generic;

public class UIController : Singleton<UIController>
{
    public GameObject initialPanel;
    public GameObject sideMenuPanel;
    public GameObject FireFighterListMenuPanel;
    public GameObject TaskListMenuPanel;
    public GameObject FighterDetailPanel;
    public GameObject FighterTaskPanel;
    public GameObject TaskAssignPanel;
    public FireFighterListSO firefighterData;
    public TaskListSO taskData;
    private Stack<GameObject> panelStack = new Stack<GameObject>();
    private GameObject currentPanel;

    protected override void Awake()
    {
        base.Awake();
        if (initialPanel != null)
        {
            initialPanel.SetActive(true);
            currentPanel = initialPanel;
        }
    }

    public void ShowPanel(GameObject newPanel)
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
            if (currentPanel == initialPanel)
            {
                panelStack.Push(currentPanel);
            }
        }
        newPanel.SetActive(true);
        currentPanel = newPanel;
    }

    public void Back()
    {
        if (panelStack.Count > 0)
        {
            if (currentPanel != null)
            {
                /*Debug.Log("overhere2");*/
                currentPanel.SetActive(false);
            }
            currentPanel = panelStack.Pop();
            currentPanel.SetActive(true);
        }
    }

    public void ClearStack()
    {
        if (currentPanel != null && currentPanel != initialPanel)
        {
            currentPanel.SetActive(false);
        }
        panelStack.Clear();
        initialPanel.SetActive(true);
        currentPanel = initialPanel;
    }

    public FireFighterListSO GetFirefighterData()
    {
        return firefighterData;
    }

    public TaskListSO GetTaskData()
    {
        return taskData;
    }
}
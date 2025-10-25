using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TaskListSO", menuName = "ScriptableObjects/TaskList")]
public class TaskListSO : ScriptableObject
{
    [System.Serializable]
    public class TaskData
    {
        public string description; // ��������, e.g., "Extinguish fire on floor 2"
        public string status; // ����״̬, e.g., "Pending"
        public string assignee; // ִ����, e.g., "FF001 - John"
    }

    public List<TaskData> tasks = new List<TaskData>(); // д����������
}
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TaskListSO", menuName = "ScriptableObjects/TaskList")]
public class TaskListSO : ScriptableObject
{
    [System.Serializable]
    public class TaskData
    {
        public string description; // 任务描述, e.g., "Extinguish fire on floor 2"
        public string status; // 任务状态, e.g., "Pending"
        public string assignee; // 执行人, e.g., "FF001 - John"
    }

    public List<TaskData> tasks = new List<TaskData>(); // 写死三个任务
}
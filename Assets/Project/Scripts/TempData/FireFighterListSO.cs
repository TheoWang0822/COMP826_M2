using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "FireFighterListSO", menuName = "ScriptableObjects/FirefighterList")]
public class FireFighterListSO : ScriptableObject
{
    [System.Serializable]
    public class Firefighter
    {
        public string id;
        public string name;
        public string status;
        public Vector3 location;
        public string task;
    }

    public List<Firefighter> firefighters = new List<Firefighter>();
}
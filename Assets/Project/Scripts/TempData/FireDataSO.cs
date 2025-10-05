using UnityEngine;

[CreateAssetMenu(fileName = "FireData", menuName = "Data/Fire Data")]
public class FireDataSO : ScriptableObject
{
    // isOnFire[i] indicates whether level i+1 is on fire
    public bool[] isOnFire = new bool[5];
}
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int id;
    public FloorType isCeiling = FloorType.Floor;
    private bool isVisible;
    void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVisiblity(bool val)
    {
        isVisible = val;
    }

}

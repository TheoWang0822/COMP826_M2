using UnityEngine;

public class Floor : MonoBehaviour
{
    public int id;
    public FloorType isCeiling = FloorType.Floor;
    private bool isVisible = true;
    private bool isOnFire = false;
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
    public void SetVisible(bool val)
    {
        transform.Find("Roof1")?.gameObject.SetActive(!val);
        transform.Find("Roof2")?.gameObject.SetActive(!val);
        gameObject.SetActive(val);
        isVisible = val;
    }
    public void SetVisible()
    {
        transform.Find("Roof1")?.gameObject.SetActive(true);
        transform.Find("Roof2")?.gameObject.SetActive(true);
        gameObject.SetActive(true);
        isVisible = true;
    }
    public void SetHighlight(bool val)
    {
        transform.Find("Highlight")?.gameObject.SetActive(val);
        transform.GetChild(0).Find("Highlight")?.gameObject.SetActive(val);
        isOnFire = val;
    }

    public void SetHighlight()
    {
        transform.Find("Highlight")?.gameObject.SetActive(false);
        transform.GetChild(0).Find("Highlight")?.gameObject.SetActive(false);
    }


}

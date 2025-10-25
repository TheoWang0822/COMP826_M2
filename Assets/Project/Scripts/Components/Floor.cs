using UnityEngine;

public class Floor : MonoBehaviour
{
    public int id;
    public FloorType isCeiling = FloorType.Floor;
    private bool isVisible = true;
    private bool isOnFire = false;
    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject C4;
    void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*for (int i = 0; i < 2; i++) 
        {
            for (int j = 0; i < 2; j++)
            {

            }
        }*/
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

    public void setFirefighterHL(int x, int y)
    {
        if (x == 1 && y == 1)
        {
            C1.SetActive(true);
        }

        if (x == 1 && y == 2)
        {
            C2.SetActive(true);
        }

        if (x == 2 && y == 1)
        {
            C3.SetActive(true);
        }

        if (x == 2 && y == 2)
        {
            C4.SetActive(true);
        }
    }


}

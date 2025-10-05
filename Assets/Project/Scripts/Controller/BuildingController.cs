using UnityEngine;
using System.Collections.Generic;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    List<Floor> floorList = new();

    int current = -1;
    void OnEnable()
    {
        EventsHub.FloorClicked += Select;
    }

    void OnDisable() 
    {
        EventsHub.FloorClicked -= Select;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(Floor floor)
    {
        if (floor == null) return;
        int id = floor.id;
        if(current == id){
            // Go back to Overview
            GoBackOverview();
            return;
        }
        current = id;
        foreach (var value in floorList)
        {
            value.gameObject.transform.Find("Roof1")?.gameObject.SetActive(value.id > current);
            value.gameObject.transform.Find("Roof2")?.gameObject.SetActive(value.id > current);
            value.gameObject.SetActive(value.id <= current);
        }


    }

    private void GoBackOverview()
    {
        current = -1;
        foreach (var value in floorList)
        {
            value.gameObject.SetActive(true);
            value.gameObject.transform.Find("Roof1")?.gameObject.SetActive(true);
            value.gameObject.transform.Find("Roof2")?.gameObject.SetActive(true);
        }
    }


}

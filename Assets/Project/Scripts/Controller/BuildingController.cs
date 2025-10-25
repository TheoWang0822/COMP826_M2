using UnityEngine;
using System.Collections.Generic;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    List<Floor> floorList = new();
    [SerializeField]
    private FireDataSO fireData;
    [SerializeField]
    private FireFighterListSO fighterData;

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
        GoBackOverview();
        FighterHighlight();
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
        int count = 1;
        foreach (var value in floorList)
        {
            value.SetVisible(value.id <= current);
            if (count == current)
            {
                value.SetHighlight();
            }
            count++;
        }
    }

    private void GoBackOverview()
    {
        current = -1;
        int count = 0;
        foreach (var value in floorList)
        {
            value.SetVisible();
            value.SetHighlight(fireData.isOnFire[count]);
            /*fireData.isOnFire[count];*/
            count++;
        }
    }

    public void FighterHighlight()
    {
        foreach (var firefighter in fighterData.firefighters)
        {
            int floorNumber = (int)firefighter.location.z;

            if (floorNumber >= 1 && floorNumber <= floorList.Count)
            {
                Floor targetFloor = floorList[floorNumber - 1];
                targetFloor.setFirefighterHL((int)firefighter.location.x, (int)firefighter.location.y);
            }
        }
    }

}

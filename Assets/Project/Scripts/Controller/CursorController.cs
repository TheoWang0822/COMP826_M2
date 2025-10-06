using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{
    public Camera cam;
    public LayerMask floorMask;
    public BuildingController building;

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
            TryPick(Input.mousePosition);*/


        if (Input.GetMouseButtonDown(0))
        {
            
            // if raycast hit UI, return
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            // otherwise 3D Raycast floor logic
            TryPick(Input.mousePosition);
        }
    }

    void TryPick(Vector2 screenPos)
    {
        var ray = cam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out var hit, 500f, floorMask))
        {
            var floor = hit.collider.transform.GetComponentInParent<Floor>();
            EventsHub.RaiseClicked(floor);
        }
    }
}

using UnityEngine;
using System;

public static class EventsHub
{
    public static event Action<Floor> FloorClicked;
    public static void RaiseClicked (Floor floor)
    {
        FloorClicked?.Invoke(floor);
    }
}

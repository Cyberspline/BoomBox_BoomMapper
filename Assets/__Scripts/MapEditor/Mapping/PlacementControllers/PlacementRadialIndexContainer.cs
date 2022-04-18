using System;
using UnityEngine;

public class PlacementRadialIndexContainer : MonoBehaviour
{
    public MonoBehaviour Owner;

    public int RadialIndex
    {
        get => radialIndex ?? -1;
        set
        {
            if (radialIndex != null)
            {
                throw new InvalidOperationException("Radial Index is already assigned.");
            }

            radialIndex = value;
        }
    }

    private int? radialIndex;
}

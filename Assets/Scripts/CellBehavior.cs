using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehavior : MonoBehaviour
{
    WallBehaviour[] walls;

    public bool NorthConnected = false;
    public bool SouthConnected = false;
    public bool EastConnected = false;
    public bool WestConnected = false;

    public float Width;
    public float Height;

    // Start is called before the first frame update
    void Start()
    {
        walls = GetComponentsInChildren<WallBehaviour>();

        foreach(var wall in walls)
        {
            switch (wall.WallSide)
            {
                case Connection.North:
                    if (NorthConnected)
                    {
                        wall.DisableWall();
                    }
                    break;

                case Connection.South:
                    if (SouthConnected)
                    {
                        wall.DisableWall();
                    }
                    break;

                case Connection.East:
                    if (EastConnected)
                    {
                        wall.DisableWall();
                    }
                    break;

                case Connection.West:
                    if (WestConnected)
                    {
                        wall.DisableWall();
                    }
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Connection
{
    North, South, East, West
}

public class WallBehaviour : MonoBehaviour
{
    public Connection WallSide = Connection.North;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableWall()
    {
        gameObject.SetActive(false);
        GameObject.Destroy(gameObject, 10);
    }
}

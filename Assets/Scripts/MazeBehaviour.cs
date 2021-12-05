using MazeGen;
using UnityEngine;

public class MazeBehaviour : MonoBehaviour
{
    public GameObject CellPrefab;
    public int Columns;
    public int Rows;

    // Start is called before the first frame update
    private void Start()
    {
        Maze maze = MazeGenerator.Generate(Columns, Rows);
        var cellTemplate = CellPrefab.GetComponent<CellBehavior>();
        for (int x = 0; x < Columns; x++)
        {
            for (int z = 0; z < Rows; z++)
            {
                var cell = Instantiate(CellPrefab, 
                    new Vector3(x * cellTemplate.Width, 0, -(z * cellTemplate.Height)), 
                    Quaternion.identity);

                var cellSettings = cell.GetComponent<CellBehavior>();
                var cellIndex = z * Columns + x;
                var mazeCell = maze[cellIndex];

                cellSettings.NorthConnected = mazeCell.ConnectedCellID(Direction.North) != Maze.InvalidCell;
                cellSettings.SouthConnected = mazeCell.ConnectedCellID(Direction.South) != Maze.InvalidCell;
                cellSettings.EastConnected = mazeCell.ConnectedCellID(Direction.East) != Maze.InvalidCell;
                cellSettings.WestConnected = mazeCell.ConnectedCellID(Direction.West) != Maze.InvalidCell;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
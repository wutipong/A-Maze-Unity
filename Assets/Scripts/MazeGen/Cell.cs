using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public class Cell
    {
        public int Id { get; internal set; }

        private readonly Dictionary<Direction, int> connectedCells = new();
        public Cell(int id)
        {
            Id = id;
            
            connectedCells[Direction.North] = Maze.InvalidCell;
            connectedCells[Direction.South] = Maze.InvalidCell;
            connectedCells[Direction.East] = Maze.InvalidCell;
            connectedCells[Direction.West] = Maze.InvalidCell;
        }

        public void ConectsTo(Cell to, Direction direction)
        {
            connectedCells[direction] = to.Id;
            to.connectedCells[direction.Opposite()] = Id;
        }

        public int ConnectedCellID(Direction direction)
        {
            return connectedCells[direction];
        }
    }
}

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

        private Dictionary<Direction, int> connectedCells;
        public Cell(int id)
        {
            Id = id;
            
            connectedCells[Direction.North] = Maze.InvalidCell;
            connectedCells[Direction.South] = Maze.InvalidCell;
            connectedCells[Direction.East] = Maze.InvalidCell;
            connectedCells[Direction.West] = Maze.InvalidCell;
        }

        void ConectsTo(ref Cell to, Direction direction)
        {
            connectedCells[direction] = to.Id;
            to.connectedCells[direction.Opposite()] = Id;
        }
    }
}

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

        private readonly int[] connectedCells = {Maze.InvalidCell, Maze.InvalidCell, Maze.InvalidCell, Maze.InvalidCell};
        public Cell(int id)
        {
            Id = id;
        }

        public void ConectsTo(Cell to, Direction direction)
        {
            connectedCells[(int)direction] = to.Id;
            to.connectedCells[(int)direction.Opposite()] = Id;
        }

        public int ConnectedCellID(Direction direction)
        {
            return connectedCells[(int)direction];
        }
    }
}

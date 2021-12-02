using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public class Maze
    {
        public const int InvalidCell = -1;

        public int Columns { get; private set; }
        public int Rows { get; private set; }

        public int CellCounts { get { return Rows * Columns; } }

        private Cell[] cells;

        public Cell this[int index] { get { return cells[index]; } set { cells[index] = value; } }

        public Maze(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;

            cells = new Cell[CellCounts];

            for(int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell(i);
            }
        }

        public int AdjacentCellID(int id, Direction direction) {
            if (id < 0 || id >= CellCounts)
                return InvalidCell;

            var (x, y) = CellPosition(id);

            switch (direction)
            {
                case Direction.North:
                    y = y - 1;
                    break;

                case Direction.South:
                    y = y + 1;
                    break;

                case Direction.West:
                    x = x - 1;
                    break;
                case Direction.East:
                    x = x + 1;
                    break;
            }

            if (x < 0 || x >= Columns)
                return InvalidCell;

            if (y < 0 || y >= Rows)
                return InvalidCell;

            return (y * Columns) + x;
        }

        public (int x, int y) CellPosition(int id)
        {
            int x = id % Columns;
            int y = id / Columns;

            return (x, y);
        }
    }
}

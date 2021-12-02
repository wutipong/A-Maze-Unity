using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public static class MazeGenerator
    {
        public static Maze Generate(int columns, int rows)
        {
            Maze maze =  new(columns, rows);
            MazeContext ctx = new (maze);

            while(ctx.CurrentSetCount != 1)
            {
                var (from, to, direction, opposite) = ctx.RandomJoin();

                var fromCell = maze[from];
                var toCell = maze[to];

                fromCell.ConectsTo(ref toCell, direction);

            }

            return maze;
        }
    }
}

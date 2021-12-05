using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public static class MazeGenerator
    {
        public static Maze Generate(int columns, int rows, Random? random = null, ILogger ? logger = null)
        {
            Maze maze =  new(columns, rows);
            MazeContext ctx = new (maze);

            if (random == null) random = new Random();

            logger?.Write(string.Format("[Maze.Generate()] creating a maze with size {0} x {1}.", columns, rows));

            while (ctx.CurrentSetCount != 1)
            {
                var (from, to, direction) = ctx.RandomJoin(random);

                var fromCell = maze[from];
                var toCell = maze[to];

                fromCell.ConectsTo(toCell, direction);
                logger?.Write(string.Format("[Maze.Generate()] connects {0} to {1}.", from, to));
            }

            return maze;
        }
    }
}

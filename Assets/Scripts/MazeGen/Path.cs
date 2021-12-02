using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public struct PathNode
    {
        public int Cell { get; internal set; }
        public Direction FromDirection { get; internal set; }
        public Direction ToDirection { get; internal set; }
    }
    public class Path
    {
        private List<PathNode> nodes = new List<PathNode>();

        public PathNode this[int index] { get { return nodes[index]; } }
        public int Count { get { return nodes.Count; } }

        private static Direction Next(Direction direction)
        {
            return direction switch
            {
                Direction.Invalid => Direction.North,
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.Invalid,
                _ => Direction.Invalid,
            };
        }
        public static Path DepthFirstSearch(Maze maze, int from, int to)
        {
            Path path = new();
            path.nodes.Add(new PathNode
            {
                Cell = from,
                FromDirection = Direction.Invalid,
                ToDirection = Direction.Invalid
            });

            if (from == to) { return path; }

            while(true)
            {
                var currentIndex = path.nodes.Count-1;
                var current = path.nodes[currentIndex];
                if (current.Cell == to) break;

                var cell = maze[current.Cell];
                current.ToDirection = Next(current.ToDirection);
                path.nodes[currentIndex] = current;

                if(current.ToDirection == Direction.Invalid)
                {
                    path.nodes.RemoveAt(currentIndex);
                    continue;
                }

                if(current.ToDirection == current.FromDirection)
                {
                    continue;
                }

                var nextCell = cell.ConnectedCellID(current.ToDirection);
                if(nextCell == Maze.InvalidCell)
                {
                    continue;
                }

                var next = new PathNode
                {
                    Cell = maze.AdjacentCellID(current.Cell, current.ToDirection),
                    FromDirection = current.ToDirection.Opposite(),
                    ToDirection = Direction.Invalid,
                };

                path.nodes.Add(next);
            }

            return null;
        }
    }
}

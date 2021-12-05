using System;
using System.Collections.Generic;

namespace MazeGen
{
    internal class MazeContext
    {
        private HashSet<int>[] disjointSets;
        internal int CurrentSetCount { get; private set; }

        internal int Columns { get; private set; }
        internal int Rows { get; private set; }

        internal int CellCount
        { get { return Columns * Rows; } }

        private Maze maze;

        internal MazeContext(Maze maze)
        {
            this.maze = maze;

            Columns = maze.Columns; 
            Rows = maze.Rows;
            disjointSets = new HashSet<int>[CellCount];

            for (int i = 0; i < CellCount; i++)
            {
                disjointSets[i] = new HashSet<int>
                {
                    i
                };
            }

            CurrentSetCount = CellCount;
        }

        internal bool TryJoinSet(int to, int from)
        {
            if (to == Maze.InvalidCell)
                return false;

            if (from == Maze.InvalidCell)
                return false;

            var toSet = disjointSets[to];
            var fromSet = disjointSets[from];

            if(toSet.Overlaps(fromSet)) return false;
            
            foreach (var c in fromSet)
            {
                toSet.Add(c);
                disjointSets[c] = toSet;
            }

            return true;
        }

        private static int RandomCell(Random random, int cellCount)
        {
            return random.Next(cellCount);
        }

        private static Direction RandomDirection(Random random)
        {
            return random.Next(4) switch
            {
                0 => Direction.North,
                1 => Direction.South,
                2 => Direction.West,
                3 => Direction.East,
                _ => Direction.Invalid,
            };
        }

        internal (int from, int to, Direction direction) RandomJoin(Random random)
        {
            while (true)
            {
                var fromCell = RandomCell(random, CellCount);
                var direction = RandomDirection(random);

                var toCell = maze.AdjacentCellID(fromCell, direction);

                if (TryJoinSet(toCell, fromCell))
                {
                    CurrentSetCount--;
                    return (fromCell, toCell, direction);
                }
            }
        }
    }
}
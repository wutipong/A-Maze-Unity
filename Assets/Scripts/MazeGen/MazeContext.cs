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

            if (toSet.Overlaps(fromSet)) return false;
            foreach (var c in fromSet)
            {
                toSet.Add(c);
            }

            disjointSets[from] = disjointSets[to];

            return true;
        }

        private static int RandomCell(int cellCount)
        {
            return new Random(cellCount).Next();
        }

        private static Direction RandomDirection()
        {
            int random = new Random(4).Next();
            switch (random)
            {
                case 0: return Direction.North;
                case 1: return Direction.South;
                case 2: return Direction.West;
                case 3: return Direction.East;

                default: return Direction.Invalid;
            }
        }

        internal (int from, int to, Direction direction, Direction opposite) RandomJoin()
        {
            while (true)
            {
                var fromCell = RandomCell(CellCount);
                var direction = RandomDirection();
                var toCell = maze.AdjacentCellID(fromCell, direction);

                if (TryJoinSet(toCell, fromCell))
                {
                    return (fromCell, toCell, direction, direction.Opposite());
                }
            }
        }
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGen;

public class MazeTest
{
    [Test]
    public void TestGenerate()
    {
        Maze m = MazeGenerator.Generate(6, 5);
        Assert.IsNotNull(m);
        Assert.AreEqual(6, m.Columns);
        Assert.AreEqual(5, m.Rows);
        Assert.AreEqual(30, m.CellCount);
    }
}


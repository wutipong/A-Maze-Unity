using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGen;

public class PathTest
{
    [Test]
    public void TestDepthFirstSearch()
    {
        Maze m = MazeGenerator.Generate(6, 5);
        Path p = Path.DepthFirstSearch(m, 2, 20);

        Assert.IsNotNull(p);
        Assert.AreEqual(2, p[0]);
        Assert.AreEqual(20, p[p.Count -1]);
        
    }
}


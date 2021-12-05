using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGen
{
    public interface ILogger
    {
        void Write(string message);
    }
}

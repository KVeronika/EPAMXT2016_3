using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._8
{
    class BaseGameObject : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public bool IsDestroyed()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._8.GameObjects
{
    abstract class Bonus : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Points { get; set; }

        public abstract void Destroy();

        public abstract bool IsDestroyed();
    }
}

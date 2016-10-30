using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._8.GameObjects
{
    abstract class Barrier : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Damage { get; set; }

        public abstract void Destroy();
        public abstract bool IsDestroyed();
    }
}

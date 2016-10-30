using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._8.GameObjects
{
    abstract class Monster : BaseGameObject, IMoveble
    {
        public int Health { get; set; }
        public int Damage { get; set; }

        public abstract bool CanMove();
        public abstract void Move();
    }
}

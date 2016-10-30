using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._8.GameObjects
{
    class Player : BaseGameObject, IMoveble
    {
        public int Health { get; set; }
        public int Score { get; set; }

        public bool CanMove()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}

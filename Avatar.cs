using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeckTest
{
    class Avatar
    {
        public string AvatarName { get; set; }
        public int Health { get; set; }

        public Avatar() {
            AvatarName = "enemy";
            Health = 15;
        }

    }
}

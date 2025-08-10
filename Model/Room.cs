using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Model
{
    public class Room
    {
        internal object roomName;

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int TeacherId { get; set; }



    }
}
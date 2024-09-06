using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistApp
{
    public class Track
    {
        public string Name { get; set; }
        public Track Next { get; set; }
        public Track Previous { get; set; }

        public Track(string name)
        {
            Name = name;
            Next = null;
            Previous = null;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}

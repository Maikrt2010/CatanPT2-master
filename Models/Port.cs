using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Port
    {
        public Port( string conversion, int placement )
        {
            
            this.Conversion = conversion;
            this.Placement = placement;
            
        }

        public Port()
        {

        }

      
        public string Conversion { get;  set; }
        public int Placement { get;  set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tile
    {
        public Tile(int chip, string resource, int position)
        {
            this.Chip = chip;
            this.Resource = resource;
            this.Position = position;
        }

        public Tile()
        {

        }

        public Tile(int chip, string resource)
        {
            Chip = chip;
            Resource = resource;
        }

        public int Chip { get; set; }
        /*
         * Subject to change towards actuall DataValues
         * Please check and manifest working type DataValues further.
         * DAT BETEKENT: Tile voldoet nog niet aan alle data eisen die wij hebben uitgezet. moet veranderd worden.
        */
        public string Resource { get; set; }
        public int Position { get; set; }

    }
}

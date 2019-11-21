using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catan.Models
{
    [Serializable]
    public class Settingsmodel
    {
        public bool TileIsRandom { get; set; }

        public bool IsSmallBoard { get; set; }

        public ChipState ChipState { get; set; }
    }

    public enum ChipState
    {
        Random,
        Fixed,
        Psuedo
    };
}

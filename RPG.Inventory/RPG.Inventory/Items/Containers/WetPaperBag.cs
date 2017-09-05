using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class WetPaperBag : WeightRestrictedContainer
    {
        public WetPaperBag() : base(8, 3)
        {
            Name = "Wet Paper Bag";
            Description = "Damp and flimsy";
            Weight = 1;
            Type = ItemType.Container;

        }
    }
}

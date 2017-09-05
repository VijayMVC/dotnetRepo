using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class SpecificContainer : Container
    {
        private ItemType _requriedType;
        public SpecificContainer(int capacity, ItemType requiredType) : base(capacity)
        {
            _requriedType = requiredType;
        }

        public override AddItemStatus AddItem(Item ItemToAdd)
        {
            if (ItemToAdd.Type == _requriedType)
            {
                return base.AddItem(ItemToAdd);
            }
            return AddItemStatus.ItemNotRightType;
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Items.Containers;
using RPG.Inventory.Items.Potions;
using RPG.Inventory.Items;
using RPG.Inventory.Items.Weapons;

namespace RPG.Intentory.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanAddItemToBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            AddItemStatus actual = b.AddItem(p);
            Assert.AreEqual(AddItemStatus.Success, actual);

        }
        [Test]
        public void CannotAddItemToFullBackpack()
        {
            Backpack b = new Backpack();
            Sword steelSword = new Sword();

            b.AddItem(steelSword);
            b.AddItem(steelSword);
            b.AddItem(steelSword);
            b.AddItem(steelSword);

            AddItemStatus actual = b.AddItem(steelSword);
            Assert.AreEqual(AddItemStatus.BagIsFull, actual);

        }
        

        [Test]
        public void CanRemoveItemFromBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            b.AddItem(p);

            Item actual = b.RemoveItem();

            Assert.AreEqual(p, actual);
        }
        [Test]
        public void EmptyBagReturnsNull()
        {
            Backpack b = new Backpack();
            Item item = b.RemoveItem();

            Assert.IsNull(item);
        }
        [Test]
        public void PotionSatchelOnlyAllowsPotions()
        {
            PotionSatchel satchel = new PotionSatchel();
            Sword steelsword = new Sword();

            AddItemStatus result = satchel.AddItem(steelsword);
            Assert.AreEqual(AddItemStatus.ItemNotRightType,result);

            HealthPotion potion = new HealthPotion();
            result = satchel.AddItem(potion);
            Assert.AreEqual(AddItemStatus.Success,result);
        }
        [Test]
        public void WeightRestrictedBagRestrictsWeight()
        {
            WetPaperBag sack = new WetPaperBag();
            HealthPotion potion = new HealthPotion();
            Assert.AreEqual(AddItemStatus.Success, sack.AddItem(potion));

            Sword sword = new Sword();
            Assert.AreEqual(AddItemStatus.ItemTooHeavy, sack.AddItem(sword));

            Item item = sack.RemoveItem();
            Assert.AreEqual(AddItemStatus.Success, sack.AddItem(sword));
        }
        

    }
}

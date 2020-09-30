using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace HelloWorld
{
    //creates a Player class that inherits from Character class
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        //calls default constructor for Player, then calls base classes constructor
        public Player() : base()
        {
            _inventory = new Item[3];
            _hands.name = "Dem hands";
            _hands.statBoost = 0;
        }

        public Player(string name, float health, float damage, int inventorySize)
            : base(health, name, damage)
        {
            _inventory = new Item[inventorySize];
            _hands.name = "Dem hands";
            _hands.statBoost = 0;
        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex >= 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;

        }

        public void AddItemInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public override float Attack(Character enemy)
        {
            float totalDamage = _damage + _currentWeapon.statBoost;
            return enemy.TakeDamage(totalDamage);
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public void UnEquipItem()
        {
            _currentWeapon = _hands;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace HelloWorld
{
    //Player class that inherits from Character class
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

        //checks if itemIndex is longer than the array length
        public bool Contains(int itemIndex)
        {
            if (itemIndex >= 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;

        }

        //adds an item to the array index
        public void AddItemInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        //returns inventory array
        public Item[] GetInventory()
        {
            return _inventory;
        }

        //Calls & returns TakeDamage on enemy. 
        public override float Attack(Character enemy)
        {
            int _accuracy = RandomNum();
            float totalDamage = _damage + _currentWeapon.statBoost;
            //25% chance to miss attack
            if (_accuracy > 25)
            {
                return enemy.TakeDamage(totalDamage);
            }
            else
            {
                Console.WriteLine("\nyour attack missed.");
                totalDamage = 0;
                return enemy.TakeDamage(totalDamage);
            }
        }

        //sets _currentWeapon to selected weapon
        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        //sets _currentWeapon to _hands
        public void UnEquipItem()
        {
            _currentWeapon = _hands;
        }
    }
}
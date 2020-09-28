using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

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

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.Write("> ");

            input = ' ';

            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;

                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invaild input");
                }
            }
        }

    }
}
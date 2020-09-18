using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private string _role;
        private int _health;
        private int _baseDamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _baseDamage = 10;
            _hands.name = "Dem hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
        {
            _name = nameVal;
            _health = healthVal;
            _baseDamage = damageVal;
            _inventory = new Item[inventorySize];
            _hands.name = "Dem hands";
            _hands.statBoost = 0;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex >= 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
            
        }

        public void AddItemInventory (Item item, int index)
        {
            _inventory[index] = item;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }
        
        public string GetName()
        {
            return _name;
        }

        public bool GetHealth()
        {
            return _health > 0;
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _baseDamage + _currentWeapon.statBoost;
            enemy.TakeDamage(totalDamage);
        }

        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public void UnEquipItem()
        {
            _currentWeapon = _hands;
        }

        private void TakeDamage(int damageVal)
        {
            if (GetHealth())
            {
                _health -= damageVal;
            }
            Console.WriteLine("\n " + _name + " took " + damageVal + " damage!");
        }

        public void PrintStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_role);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _baseDamage);
        }

        public void ChooseRole(Player player)
        {
            GetInput(out char input, "Mage", "Rogue", "Knight", "Choose a role");

            switch (input)
            {
                case '1':
                    _role = "mage";
                    _health = 50;
                    _baseDamage = 25;
                    break;
                case '2':
                    _role = "Rogue";
                    _health = 25;
                    _baseDamage = 50;
                    break;
                case '3':
                    _role = "Knight";
                    _health = 125;
                    _baseDamage = 15;
                    break;
            }
            Console.Clear();
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

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace HelloWorld
{
    //Player class that inherits from Character class
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;
        private string _specialty;
        private int _specialtyNum;

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

        public string GetSpecialty()
        {
            return _specialty;
        }

        public int LoadSpecialty()
        {
            return _specialtyNum;
        }

        public void GiveSpecialty(string specialty, int specialtyNum)
        {
            _specialty = specialty;
            _specialtyNum = specialtyNum;
        }

        public void ChangeStats(float health, float damage)
        {
            _health = health;
            _damage = damage;
        }

        public void PrintSPStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_specialty);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }

        public void SaveSP(StreamWriter writer)
        {
            //Saves the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
            writer.WriteLine(_specialtyNum);
        }

        public bool LoadSP(StreamReader reader)
        {
            //creates variables to store loaded data
            string name = reader.ReadLine();
            float health = 0;
            float damage = 0;
            int specialty = 0;
            //checks to see if loading was successful.
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out specialty) == false)
            {
                return false;
            }
            //if successful, updates the member variables and returns true.
            _name = name;
            _health = health;
            _damage = damage;
            _specialtyNum = specialty;
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace HelloWorld
{
    class Player
    {

        private int _health;
        private int _damage;
        private string _name;

        public Player()
        {
            _health = 100;
            _damage = 10;
        }
        public void EquipItem(Item weapon)
        {
            _damage += weapon.statBoost;
        }
        public Player(string nameVal, int healthVal, int damageVal)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void Attack(Player enemy)
        {
            enemy.TakeDamage(_damage);
        }

        private void TakeDamage(int damageVal)
        {
            if (GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine("\n " + _name + " did " + damageVal + " damage!");
        }
        public void PrintStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        private string _name;
        protected float _damage;

        public Character()
        {
            _health = 100;
            _name = "Bob";
            _damage = 10;
        }

        public Character(float health, string name, float damage)
        {
            _health = health;
            _name = name;
            _damage = damage;
        }

        public virtual float Attack(Character enemy)
        {
            return enemy.TakeDamage(_damage);
        }

        public virtual float TakeDamage(float damage)
        {
            _health -= damage;
            if (_health < 0)
            {
                _health = 0;
            }
            return damage;
        }

        public virtual float Heal(Character player)
        {
            return player.GiveHealth(30);
        }

        public virtual float GiveHealth(float healing)
        {
            _health += healing;
            if (_health >= 100)
            {
                _health = 100;
                Console.WriteLine("You've been restored to full health");
            }
            return healing;
        }

        public virtual void Save(StreamWriter writer)
        {
            //Saves the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
        }

        public virtual bool Load(StreamReader reader)
        {
            //create variables to store loaded data
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            //checks to see if loading was successful.
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            //if successful, set update the member variables and return true.
            _name = name;
            _damage = damage;
            _health = health;
            return true;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetHealth()
        {
            return _health > 0;
        }

        public void PrintStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }
    }
}
using System;
using System.Collections.Generic;
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

        public Character(float healthVal, string nameVal, float damageVal)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
        }

        public virtual float Attack(Character enemy)
        {
            return enemy.TakeDamage(_damage);
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if (_health < 0)
            {
                _health = 0;
            }
            return damageVal;
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

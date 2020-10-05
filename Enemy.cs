using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy : Character
    {
        private int _gold;

        public Enemy()
        {
            _health = 100;
            _damage = 20;
            _name = "unKnown";
            _gold = 0;
        }

        public Enemy(float health, float damage, string name)
        {
            _health = health;
            _damage = damage;
            _name = name;
        }

        public override float Attack(Character enemy)
        {
            int _accuracy = RandomNum();
            float totalDamage = _damage;

            if (_accuracy > 40)
            {
                return enemy.TakeDamage(totalDamage);
            }
            else
            {
                Console.WriteLine("\n" + "the " + _name + "'s attack missed.");
                totalDamage = 0;
                return enemy.TakeDamage(totalDamage);
            }
        }
    }
}

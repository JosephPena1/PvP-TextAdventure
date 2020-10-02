using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    //Wizard class that inherits from Character class
    class Wizard : Character
    {
        private float _mana;

        //calls default constructor for Wizard, then calls base classes constructor
        public Wizard() : base()
        {
            _mana = 100;
        }

        public Wizard(float health, string name, float damage, float mana) : base(health, name, damage)
        {
            _mana = mana;
        }

        //Calls & returns TakeDamage on enemy if Wizard's mana >= 4. else calls base attack function.
        public override float Attack(Character enemy)
        {
            if (_mana >= 4)
            {
                float totalDamage = _damage + _mana * .25f;
                _mana -= _mana * .25f;
                return enemy.TakeDamage(totalDamage);
            }
            return base.Attack(enemy);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Wizard : Character
    {
        private float _mana;

        //calss default constructor for Wizard, then calls base classes constructor
        public Wizard() : base()
        {
            _mana = 100;
        }

        public Wizard(float healthVal, string nameVal, float damageVal, float manaVal) : base(healthVal, nameVal, damageVal)
        {
            _mana = manaVal;
        }

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

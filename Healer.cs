using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Healer : Character
    {
        private float _mana;
        private float _healing;

        //calls default constructor for Healer, then calls base classes constructor
        public Healer() : base()
        {
            _mana = 100;
            _healing = 50;
        }

        public Healer(float health, string name, float damage, float mana, float healing) : base(health, name, damage)
        {
            _mana = mana;
            _healing = healing;
        }

        public override float Heal(Character player)
        {
            if (_mana >= 4)
            {
                float totalHealing =  + _mana * .30f;
                _mana -= _mana * .25f;
                return player.GiveHealth(totalHealing);
            }
            return base.Heal(player);
        }
    }
}

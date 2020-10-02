using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    //Healer class that inherits from Character class
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

        //Calls & returns GiveHeal + healing on player if mana >= 8. else calls base Heal function
        public override float Heal(Character player)
        {
            if (_mana >= 8)
            {
                float totalHealing = +_mana * .20f;
                _mana -= _mana * .25f;
                return player.GiveHealth(totalHealing);
            }
            return base.Heal(player);
        }
    }
}
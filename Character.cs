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
        private int _loadout;
        private int _partner;

        public Character()
        {
            _health = 100;
            _name = "Bob";
            _damage = 10;
            _loadout = 1;
            _partner = 1;
        }

        public Character(float health, string name, float damage)
        {
            _health = health;
            _name = name;
            _damage = damage;
        }

        //Calls & returns TakeDamage on enemy.
        public virtual float Attack(Character enemy)
        {
            return enemy.TakeDamage(_damage);
        }

        //Reduces enemy's health by given damage, then returns damage.
        public virtual float TakeDamage(float damage)
        {
            _health -= damage;
            if (_health < 0)
            {
                _health = 0;
            }
            return damage;
        }

        //Calls & returns GiveHeal on player.
        public virtual float Heal(Character player)
        {
            return player.GiveHealth(30);
        }

        //Increases player's health with healing, then returns healing
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
        //saves stats, loadout and partner for the player
        public virtual void Save(StreamWriter writer)
        {
            //Saves the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
            writer.WriteLine(_loadout);
            writer.WriteLine(_partner);
        }

        //loads stats, loadout and partner for the player
        public virtual bool Load(StreamReader reader)
        {
            //creates variables to store loaded data
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            int loadout = 0;
            int partner = 0;
            //checks to see if loading was successful.
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out loadout) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out partner) == false)
            {
                return false;
            }
            //if successful, updates the member variables and returns true.
            _name = name;
            _damage = damage;
            _health = health;
            _loadout = loadout;
            _partner = partner;
            return true;
        }

        //returns name
        public string GetName()
        {
            return _name;
        }

        //returns health
        public bool GetHealth()
        {
            return _health > 0;
        }

        //sets loadout to the given parameter
        public void GiveLoadout(int loadout)
        {
            _loadout = loadout;
        }

        //returns loadout
        public int LoadLoadout(Player player)
        {
            return _loadout;
        }

        //sets partner to the given parameter
        public void GivePartner(int partner)
        {
            _partner = partner;
        }

        //returns partner
        public int LoadPartner(Player player)
        {
            return _partner;
        }

        //prints stats to screen
        public void PrintStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }

        //returns a random number between 1-100
        public int RandomNum()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
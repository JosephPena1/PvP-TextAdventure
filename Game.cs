using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HelloWorld
{

    struct Item
    {
        public string name;
        public int statBoost;
    }

    class Game
    {
        bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;
        private Item _sword;
        private Item _dagger;
        private Item _crossBow;

        private Item _sharpSword;
        private Item _sharpDagger;
        private Item _compoundBow;
        //Run the game
        public void Run()
        {

            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            Console.Clear();
            InitializeItems();
            _player1Partner = new Wizard(120, "Marlin", 20, 100);
            _player2Partner = new Wizard(60, "Mr. lin", 10, 50);

        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacters();
            _player2 = CreateCharacters();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("press any key to exit");
            ClearScreen();
            return;
        }


        public void InitializeItems()
        {
            _sword.statBoost = 15;
            _sword.name = "Sword";
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _crossBow.statBoost = 20;
            _crossBow.name = "Crossbow";

            _sharpSword.name = "Sharp Sword";
            _sharpSword.statBoost = 15;
            _sharpDagger.name = "Sharp Dagger";
            _sharpDagger.statBoost = 30;
            _compoundBow.name = "Compound Bow";
            _compoundBow.statBoost = 50;
        }


        public void StartBattle()
        {
            Console.WriteLine("");
            while (_player1.GetHealth() && _player2.GetHealth())
            {
                //player 1's turn
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                _player2.PrintStats();

                char input;
                GetInput(out input, "Attack", "Change Weapon", "\n" + _player1.GetName() + "'s turn");

                if (input == '1')
                {
                    float damageTaken = _player1.Attack(_player2);
                    Console.WriteLine("\n" + _player1.GetName() + " did " + damageTaken + " damage.");
                    damageTaken = _player1Partner.Attack(_player2);
                    Console.WriteLine(_player1Partner.GetName() + " did " + damageTaken + " damage.");

                    if (_player2.GetHealth() == false)
                    {
                        ClearScreen();
                        Console.WriteLine(_player1.GetName() + " Won!");
                        _gameOver = true;
                        return;
                    }

                }
                else
                {
                    Console.Clear();
                    SwitchWeapon(_player1);
                }
                ClearScreen();

                //player 2's turn
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                _player2.PrintStats();

                GetInput(out input, "Attack", "Change weapon", "\n" + _player2.GetName() + "'s turn");

                if (input == '1')
                {
                    float damageTaken = _player2.Attack(_player1);
                    Console.WriteLine("\n" + _player2.GetName() + " did " + damageTaken + " damage.");
                    damageTaken = _player2Partner.Attack(_player1);
                    Console.WriteLine(_player2Partner.GetName() + " did " + damageTaken + " damage.");

                    if (_player1.GetHealth() == false)
                    {
                        ClearScreen();
                        Console.WriteLine(_player2.GetName() + " Won!");
                        _gameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    SwitchWeapon(_player2);
                }
                ClearScreen();
            }
        }

        public void SwitchWeapon(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';

            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine("\n" + (i + 1) + ". " + inventory[i].name + "\n Damage: " + inventory[i].statBoost);
            }
            //GetInput(out input, inventory[0].name, inventory[1].name, inventory[2].name, "\n choose a weapon");
            Console.Write("> ");
            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("\nYou equipped " + inventory[0].name);
                        Console.WriteLine("Base damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("\nYou equipped " + inventory[1].name);
                        Console.WriteLine("Base damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("\nYou equipped " + inventory[2].name);
                        Console.WriteLine("Base damage increased by " + inventory[2].statBoost);
                        break;
                    }

                default:
                    {
                        player.UnEquipItem();
                        Console.WriteLine("It seems you have butterfingers. \n you dropped your weapon!");
                        break;
                    }
            }
        }

        public Player CreateCharacters()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            //player.ChooseRole(player);
            SelectLoadout(player);
            return player;
        }

        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(_sword.name);
            Console.WriteLine(_dagger.name);
            Console.WriteLine(_crossBow.name);

            Console.WriteLine("\nloadout 2: ");
            Console.WriteLine(_sharpSword.name);
            Console.WriteLine(_sharpDagger.name);
            Console.WriteLine(_compoundBow.name);

            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "\nchoose a loadout.");

            if (input == '1')
            {
                player.AddItemInventory(_sword, 0);
                player.AddItemInventory(_dagger, 1);
                player.AddItemInventory(_crossBow, 2);
            }
            else if (input == '2')
            {
                player.AddItemInventory(_sharpSword, 0);
                player.AddItemInventory(_sharpDagger, 1);
                player.AddItemInventory(_compoundBow, 2);
            }
            Console.Clear();
            player.PrintStats();
            ClearScreen();
        }

        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.Write("> ");

            input = ' ';

            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;

                if (input != '1' && input != '2')
                {
                    Console.WriteLine("invaild input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.Write("> ");

            input = ' ';

            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;

                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invaild input");
                }
            }
        }

        public void ClearScreen()
        {
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
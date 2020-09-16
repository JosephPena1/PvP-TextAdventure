using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

    struct Item
    {
        public int statBoost;
    }

    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        private Item _sword;
        private Item _dagger;
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

            //char _gameMode;
            GetInput(out char _gameMode, "SinglePlayer(WIP)", "PvP", "Choose a gamemode");
            switch (_gameMode)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("test");
                    _gameOver = true;
                    break;
                case '2':
                    Console.Clear();
                    //InitializeItems();
                    _player1 = CreateCharacters();
                    _player2 = CreateCharacters();
                    break;
            }


        }

        //Repeated until the game ends
        public void Update()
        {
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("press any key to exit");
            ClearScreen();
            return;
        }

        /*
        public void InitializeItems()
        {
            sword.statBoost = 15;
            dagger.statBoost = 10;
        }
        */

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

                //char input;

                GetInput(out char input, "Attack", "nothing", "\n" + _player1.GetName() + "'s turn");

                if (input == '1')
                {
                    _player1.Attack(_player2);
                    if (_player2.GetHealth() == false)
                    {
                        ClearScreen();
                        Console.WriteLine(_player1.GetName() + " Won!");
                        _gameOver = true;
                        return;
                    }
                }
                else if (input == '2')
                {
                    Console.WriteLine(_player1.GetName() + " did nothing");
                }
                ClearScreen();

                //player 2's turn
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                _player2.PrintStats();

                GetInput(out input, "Attack", "nothing", "\n Player 2's turn");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                    if (_player1.GetHealth() == false)
                    {
                        ClearScreen();
                        Console.WriteLine(_player2.GetName() + " Won!");
                        _gameOver = true;
                        return;
                    }
                }
                else if (input == '2')
                {
                    Console.WriteLine("Player 2 did nothing");
                }
                ClearScreen();
            }
        }

        public Player CreateCharacters()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 5);
            player.ChooseRole(player);
            GiveItems(player);
            return player;
        }

        public void GiveItems(Player player)
        {

            char input;
            GetInput(out input, "Sword", "Dagger", "choose a weapon.");

            if (input == '1')
            {
                player.AddItemInventory(_sword, 0);
            }
            else if (input == '2')
            {
                player.AddItemInventory(_dagger, 0);
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

        public void ClearScreen()
        {
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
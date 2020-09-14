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
        Item sword;
        Item dagger;
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
            //InitializePlayers();
            InitializeItems();
            
        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacters();
            _player2 = 
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("press any key to exit");
            ClearScreen();
            return;
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

        public void InitializeItems()
        {
            sword.statBoost = 15;
            dagger.statBoost = 10;
        }

        public void GiveItems(Player player)
        {

            char input;
            GetInput(out input, "Sword", "Dagger", "Player 1 choose a weapon.");

            if (input == '1')
            {
                player.EquipItem(sword);
            }
            else if (input == '2')
            {
                player.EquipItem(dagger);
            }
            Console.Clear();
            Console.WriteLine("player 1");
            player.PrintStats();
            ClearScreen();
            //input for player 2
            GetInput(out input, "Sword", "Dagger", "Player 2 choose a weapon.");

            if (input == '1')
            {
                player.EquipItem(sword);
            }
            else if (input == '2')
            {
                player.EquipItem(dagger);
            }
            Console.Clear();
            Console.WriteLine("player 2");
            player.PrintStats();
            ClearScreen();
        }

        public void StartBattle()
        {
            Console.WriteLine("");
            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {

                //player 1's turn
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                _player2.PrintStats();

                char input;

                GetInput(out input, "Attack", "nothing", "\n Player 1's turn");

                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else if (input == '2')
                {
                    Console.WriteLine("Player 1 did nothing");
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
            player = new Player(name, 100, 10);
            GiveItems(player);
            return player;
        }

        public void ClearScreen()
        {
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
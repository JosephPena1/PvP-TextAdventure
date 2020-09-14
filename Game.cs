using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

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
            InitializePlayers();
            InitializeItems();
            GiveItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("");
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

        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }

        public void InitializePlayers()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
        }

        public void InitializeItems()
        {
            sword.statBoost = 15;
            dagger.statBoost = 10;
        }

        public void GiveItems()
        {

            char input;

            //input for player 1
            GetInput(out input, "Sword", "Dagger", "Player 1 choose a weapon.");

            if (input == '1')
            {
                _player1.damage += sword.statBoost;
            }
            else if (input == '2')
            {
                _player1.damage += dagger.statBoost;
            }
            Console.Clear();
            Console.WriteLine("player 1");
            PrintStats(_player1);
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            //input for player 2
            GetInput(out input, "Sword", "Dagger", "Player 2 choose a weapon.");

            if (input == '1')
            {
                _player2.damage += sword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.statBoost;
            }
            Console.Clear();
            Console.WriteLine("player 2");
            PrintStats(_player2);
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void StartBattle()
        {
            Console.WriteLine("");
            while (_player1.health > 0 && _player2.health > 0)
            {

                //player 1's turn
                Console.WriteLine("Player 1");
                PrintStats(_player1);
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                PrintStats(_player2);

                char input;

                GetInput(out input, "Attack", "nothing", "\n Player 1's turn");

                if (input == '1')
                {
                    _player2.health -= _player1.damage;
                    Console.WriteLine("\n Player 2 took " + _player1.damage + " damage");
                    if (_player2.health <= 0)
                    {
                        Console.WriteLine("Player 1 wins!");
                        _gameOver = true;
                        return;
                    }
                }
                else if (input == '2')
                {
                    Console.WriteLine("Player 1 did nothing");
                }
                ClearScreen();

                //player 2's turn
                Console.WriteLine("Player 1");
                PrintStats(_player1);
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                PrintStats(_player2);

                GetInput(out input, "Attack", "nothing", "\n Player 2's turn");

                if (input == '1')
                {
                    _player1.health -= _player2.damage;
                    Console.WriteLine("\n Player 1 took " + _player2.damage + " damage");
                    if (_player1.health <= 0)
                    {
                        Console.WriteLine("Player 2 wins!");
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

        public void ClearScreen()
        {
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
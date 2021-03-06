﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private bool _gameOver = false;
        private bool _singlePlayerMode = false;
        private bool _PvPMode = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;
        private Item _sword;
        private Item _dagger;
        private Item _crossBow;

        private Item _sharpSword;
        private Item _sharpDagger;
        private Item _gun;

        //saves the game to PvP save file\\
        public void Save()
        {
            //creates a new stream writer.
            StreamWriter writer = new StreamWriter("saveDataPvP.txt");

            //calls save for both instances for player
            _player1.Save(writer);
            _player2.Save(writer);
            //closes writer
            writer.Close();
        }

        //loads the game from PvP load file\\
        public void Load()
        {
            //creates a new stream reader.
            StreamReader reader = new StreamReader("saveDataPvP.txt");

            //calls load for player 1 to load data
            _player1.Load(reader);
            //checks which loadout player 1 chose, and loads it.
            int loadout = _player1.LoadLoadout(_player1);
            int partner = _player1.LoadPartner(_player1);

            switch (loadout)
            {
                case 1:
                    {
                        _player1.AddItemInventory(_sword, 0);
                        _player1.AddItemInventory(_dagger, 1);
                        _player1.AddItemInventory(_crossBow, 2);
                        break;
                    }
                case 2:
                    {
                        _player1.AddItemInventory(_sharpSword, 0);
                        _player1.AddItemInventory(_sharpDagger, 1);
                        _player1.AddItemInventory(_gun, 2);
                        break;
                    }
            }

            switch (partner)
            {
                case 1:
                    {
                        _player1Partner = new Wizard(120, "Wizard", 20, 100);
                        break;
                    }
                case 2:
                    {
                        _player1Partner = new Healer(120, "Healer", 20, 100, 50);
                        break;
                    }
            }

            //calls load for player 2 to load data
            _player2.Load(reader);
            //checks which loadout player 2 chose, and loads it.
            loadout = _player2.LoadLoadout(_player2);
            partner = _player2.LoadPartner(_player2);

            switch (loadout)
            {
                case 1:
                    {
                        _player2.AddItemInventory(_sword, 0);
                        _player2.AddItemInventory(_dagger, 1);
                        _player2.AddItemInventory(_crossBow, 2);
                        break;
                    }
                case 2:
                    {
                        _player2.AddItemInventory(_sharpSword, 0);
                        _player2.AddItemInventory(_sharpDagger, 1);
                        _player2.AddItemInventory(_gun, 2);
                        break;
                    }
            }

            switch (partner)
            {
                case 1:
                    {
                        _player2Partner = new Wizard(120, "Wizard", 20, 100);
                        break;
                    }
                case 2:
                    {
                        _player2Partner = new Healer(120, "Healer", 20, 100, 50);
                        break;
                    }
            }

            //closes reader
            reader.Close();
        }

        //saves the game to SinglePlayer save file\\
        public void SaveSP()
        {
            //creates a new stream writer.
            StreamWriter writer = new StreamWriter("saveDataSP.txt");

            //calls save for both instances for player
            _player1.SaveSP(writer);
            //closes writer
            writer.Close();
        }

        //loads the game from Singleplayer load file\\
        public void LoadSP()
        {
            //creates a new stream reader.
            StreamReader reader = new StreamReader("saveDataSP.txt");

            //Loads Single player data
            _player1.LoadSP(reader);

            int specialty = _player1.LoadSpecialty();

            switch (specialty)
            {
                case 1:
                    {
                        //mage
                        _player1.ChangeStats(50, 50);
                        Console.Clear();
                        break;
                    }
                case 2:
                    {
                        //rogue
                        _player1.ChangeStats(30, 75);
                        Console.Clear();
                        break;
                    }
                case 3:
                    {
                        //knight
                        _player1.ChangeStats(150, 30);
                        Console.Clear();
                        break;
                    }
            }

            //closes reader
            reader.Close();
        }

        //initializes items
        public void InitializeItems()
        {
            _sword.name = "Sword";
            _sword.statBoost = 15;
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _crossBow.name = "Crossbow";
            _crossBow.statBoost = 20;

            _sharpSword.name = "Sharp Sword";
            _sharpSword.statBoost = 15;
            _sharpDagger.name = "Sharp Dagger";
            _sharpDagger.statBoost = 30;
            _gun.name = "Gun";
            _gun.statBoost = 80;
        }

        //starts SinglePlayer battle
        public void StartSPBattle(int randomNum)
        {

            //chooses random enemy
            Enemy enemyNPC;
            switch (randomNum)
            {
                case 1:
                    {
                        enemyNPC = new Enemy(50, 5, "Slime");
                        break;
                    }
                case 2:
                    {
                        enemyNPC = new Enemy(100, 15, "Troll");
                        break;
                    }
                case 3:
                    {
                        enemyNPC = new Enemy(200, 35, "Ogre");
                        break;
                    }
                case 4:
                    {
                        enemyNPC = new Enemy(250, 45, "Serpent");
                        break;
                    }
                case 5:
                    {
                        enemyNPC = new Enemy(300, 55, "Rock Elemental");
                        break;
                    }
                case 6:
                    {
                        enemyNPC = new Enemy(500, 75, "Dragon");
                        break;
                    }
                case 7:
                    {
                        enemyNPC = new Enemy(1000, 200, "Rock");
                        break;
                    }
                default:
                    {
                        enemyNPC = new Enemy(9999, 9999, "unKnown");
                        break;
                    }
            }
            Console.WriteLine("");

            //loops until player or enemy health is 0
            while (_player1.GetHealth() && enemyNPC.GetHealth())
            {
                //player's turn
                _player1.PrintStats();
                Console.WriteLine("");
                enemyNPC.PrintStats();

                char input;
                GetInput(out input, "Attack", "Change Weapon", "Save Game", "\n" + _player1.GetName() + "'s turn");

                switch (input)
                {
                    case '1':
                        {
                            float damageDealt = _player1.Attack(enemyNPC);
                            Console.WriteLine("\n" + _player1.GetName() + " did " + damageDealt + " damage.");

                            //checks if Enemy is alive.
                            if (enemyNPC.GetHealth() == false)
                            {
                                Console.WriteLine(enemyNPC.GetName() + " was slain");
                                ClearScreen();
                                _player1.LevelUp();
                                continue;
                                /*
                                ClearScreen();
                                Console.WriteLine(_player1.GetName() + " Won!");
                                _gameOver = true;
                                return;
                                */
                            }
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            SwitchWeapon(_player1);
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("game saved.");
                            SaveSP();
                            break;
                        }
                }

                float damageTaken = enemyNPC.Attack(_player1);
                Console.WriteLine("\n" + enemyNPC.GetName() + " did " + damageTaken + " damage.");

                //checks if player is alive
                if (_player1.GetHealth() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Typeout("You lost...");
                    if (enemyNPC.GetName() == "Rock")
                    {
                        Typeout("Did you really lose to a rock?");
                    }
                    _gameOver = true;
                    return;
                }
                ClearScreen();
            }
        }

        //starts PvP battle
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
                GetInput(out input, "Attack", "Change Weapon", "Save Game", "\n" + _player1.GetName() + "'s turn");

                switch (input)
                {
                    case '1':
                        {
                            float damageTaken = _player1.Attack(_player2);
                            Console.WriteLine("\n" + _player1.GetName() + " did " + damageTaken + " damage.");

                            //checks if player 1's partner is wizard, if not, calls heal function.
                            if (_player1Partner is Wizard)
                            {
                                damageTaken = _player1Partner.Attack(_player2);
                                Console.WriteLine(_player1Partner.GetName() + " did " + damageTaken + " damage.");
                            }
                            else
                            {
                                damageTaken = _player1Partner.Heal(_player1);
                                Console.WriteLine(_player1Partner.GetName() + " healed " + damageTaken + " damage.");
                            }

                            //checks if player 2 is alive.
                            if (_player2.GetHealth() == false)
                            {
                                ClearScreen();
                                Console.WriteLine(_player1.GetName() + " Won!");
                                _gameOver = true;
                                return;
                            }
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            SwitchWeapon(_player1);
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("game saved.");
                            Save();
                            break;
                        }
                }
                ClearScreen();

                //player 2's turn
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                _player2.PrintStats();

                input = ' ';
                GetInput(out input, "Attack", "Change weapon", "Save Game", "\n" + _player2.GetName() + "'s turn");

                switch (input)
                {
                    case '1':
                        {
                            float damageTaken = _player2.Attack(_player1);
                            Console.WriteLine("\n" + _player2.GetName() + " did " + damageTaken + " damage.");

                            //checks if player 2's partner is wizard, if not, calls heal function.
                            if (_player2Partner is Wizard)
                            {
                                damageTaken = _player2Partner.Attack(_player1);
                                Console.WriteLine(_player2Partner.GetName() + " did " + damageTaken + " damage.");
                            }
                            else
                            {
                                damageTaken = _player2Partner.Heal(_player2);
                                Console.WriteLine(_player2Partner.GetName() + " healed " + damageTaken + " damage.");
                            }

                            //checks if player 1 is alive.
                            if (_player1.GetHealth() == false)
                            {
                                ClearScreen();
                                Console.WriteLine(_player2.GetName() + " Won!");
                                _gameOver = true;
                                return;
                            }
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            SwitchWeapon(_player2);
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("game saved.");
                            Save();
                            break;
                        }
                }
                ClearScreen();
            }
        }

        //switch's the given player's weapon.
        public void SwitchWeapon(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';

            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine("\n" + (i + 1) + ". " + inventory[i].name + "\n Damage: " + inventory[i].statBoost);
            }

            Console.Write("> ");
            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("\n" + player.GetName() + " equipped " + inventory[0].name);
                        Console.WriteLine("Base damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("\n" + player.GetName() + " equipped " + inventory[1].name);
                        Console.WriteLine("Base damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("\n" + player.GetName() + " equipped " + inventory[2].name);
                        Console.WriteLine("Base damage increased by " + inventory[2].statBoost);
                        break;
                    }

                default:
                    {
                        player.UnEquipItem();
                        Console.WriteLine("\n" + player.GetName() + " stumbled and dropped thier weapon!");
                        break;
                    }
            }
        }

        //gives player the option to start a new game or load a previous one.
        public void OpenMainMenu()
        {
            char input;
            GetInput(out input, "Single Player", "PvP", "Select a mode");
            switch (input)
            {
                case '1':
                    {
                        _singlePlayerMode = true;
                        if (File.Exists("saveDataSP.txt"))
                        {
                            Console.Clear();
                            input = ' ';
                            GetInput(out input, "Create new character", "Load character", "What do you want to do?");
                            switch (input)
                            {
                                case '2':
                                    {
                                        _player1 = new Player();
                                        LoadSP();
                                        Console.Clear();
                                        return;
                                    }
                            }
                            _player1 = CreateSPCharacter();
                            SelectSpecialty(_player1);
                            _player1.PrintSPStats();
                            SaveSP();
                            ClearScreen();
                        }
                        else
                        {
                            _player1 = CreateSPCharacter();
                            SelectSpecialty(_player1);
                            _player1.PrintSPStats();
                            SaveSP();
                            ClearScreen();
                        }
                        break;
                    }
                case '2':
                    {
                        _PvPMode = true;
                        if (File.Exists("saveDataPvP.txt"))
                        {
                            Console.Clear();
                            input = ' ';
                            GetInput(out input, "Create new character", "Load character", "What do you want to do?");
                            switch (input)
                            {
                                case '2':
                                    {
                                        _player1 = new Player();
                                        _player2 = new Player();
                                        Load();
                                        Console.Clear();
                                        return;
                                    }
                            }
                            _player1 = CreateCharacters(1);
                            _player2 = CreateCharacters(2);
                            ChoosePartner();
                            Save();
                            Console.Clear();
                        }
                        else
                        {
                            _player1 = CreateCharacters(1);
                            _player2 = CreateCharacters(2);
                            ChoosePartner();
                            Save();
                            Console.Clear();
                        }
                        break;
                    }
            }
        }

        //Creates new SinglePlayer character.
        public Player CreateSPCharacter()
        {
            Console.Clear();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            return player;
        }

        //creates a new player.
        public Player CreateCharacters(int playerNum)
        {
            Console.Clear();
            Console.WriteLine("What is your name Player " + playerNum + "?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            SelectLoadout(player);
            return player;
        }

        //creates and saves a new partner based on input.
        public void ChoosePartner()
        {
            //player 1's choice
            Console.WriteLine(_player1.GetName());
            char input;
            GetInput(out input, "Wizard", "Healer", "Choose a partner");

            switch (input)
            {
                case '1':
                    {
                        _player1Partner = new Wizard(120, "Marlin", 20, 100);
                        _player1.GivePartner(1);
                        break;
                    }
                case '2':
                    {
                        _player1Partner = new Healer(120, "Marlin", 20, 100, 50);
                        _player1.GivePartner(2);
                        break;
                    }
            }
            Console.Clear();

            //player 2's choice
            Console.WriteLine(_player2.GetName());
            input = ' ';
            GetInput(out input, "Wizard", "Healer", "Choose a partner");

            switch (input)
            {
                case '1':
                    {
                        _player2Partner = new Wizard(120, "Mr. Lin", 20, 100);
                        _player2.GivePartner(1);
                        break;
                    }
                case '2':
                    {
                        _player2Partner = new Healer(120, "Mr. Lin", 20, 100, 50);
                        _player2.GivePartner(2);
                        break;
                    }
            }
            Console.Clear();
            return;
        }

        //Gives and saves a loadout based on input.
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
            Console.WriteLine(_gun.name);

            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "\nChoose a loadout.");

            switch (input)
            {
                case '1':
                    {
                        player.AddItemInventory(_sword, 0);
                        player.AddItemInventory(_dagger, 1);
                        player.AddItemInventory(_crossBow, 2);
                        player.GiveLoadout(1);
                        break;
                    }
                case '2':
                    {
                        player.AddItemInventory(_sharpSword, 0);
                        player.AddItemInventory(_sharpDagger, 1);
                        player.AddItemInventory(_gun, 2);
                        player.GiveLoadout(2);
                        break;
                    }
            }

            Console.Clear();
            player.PrintStats();
            ClearScreen();
        }

        public void SelectSpecialty(Player player)
        {
            GetInput(out char input, "Mage", "Rogue", "Knight", "Choose a Specialty.");

            switch (input)
            {
                case '1':
                    {
                        //mage
                        player.GiveSpecialty("Mage", 1);
                        player.ChangeStats(50, 50);
                        Console.WriteLine("\nyou chose " + player.GetSpecialty() + ".");
                        ClearScreen();
                        break;
                    }
                case '2':
                    {
                        //rogue
                        player.GiveSpecialty("Rogue", 2);
                        player.ChangeStats(30, 75);
                        Console.WriteLine("\nyou chose " + player.GetSpecialty() + ".");
                        ClearScreen();
                        break;
                    }
                case '3':
                    {
                        //knight
                        player.GiveSpecialty("Knight", 3);
                        player.ChangeStats(150, 30);
                        Console.WriteLine("\nyou chose " + player.GetSpecialty() + ".");
                        ClearScreen();
                        break;
                    }
            }
        }

        //takes in 4 args. and initializes input variable based on user input
        public void GetInput(out char input, string option1, string option2, string query)
        {
            Typeout(query);
            Typeout("1. " + option1);
            Typeout("2. " + option2);
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

        //takes in 5 args. and initializes input variable based on user input
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

        //returns a random number between 1 and 8
        public int RandomNum()
        {
            Random random = new Random();
            return random.Next(1, 8);
        }

        //Waits for user input, then clears the screen
        public void ClearScreen()
        {
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        static void Typeout(string message)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }

            for (int i = 0; i < message.Length; i++)
            {
                
                if (!Console.KeyAvailable)
                {
                    Console.Write(message[i]);
                    System.Threading.Thread.Sleep(30);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    break;
                }
            }
            Console.WriteLine();
        }

        //Runs the game\\
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins\\
        public void Start()
        {
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            InitializeItems();
        }

        //Repeated until the game ends\\
        public void Update()
        {
            OpenMainMenu();
            if (_singlePlayerMode == true)
            {
                while (_gameOver == false)
                {
                    StartSPBattle(RandomNum());
                }
            }
            else if (_PvPMode == true)
            {
                StartBattle();
            }
        }

        //Performed once when the game ends\\
        public void End()
        {
            Console.WriteLine("press any key to exit");
            Console.ForegroundColor = ConsoleColor.Gray;
            return;
        }
    }
}
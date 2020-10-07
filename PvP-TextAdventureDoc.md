## Code:

#### Classes and functions

**File**: Game.cs

**Attributes**

         Name: Save()
             Description: Saves the game to PvP save file.
             Type: public void

         Name: Load()
             Description: Loads the game from PvP load file.
             Type: public void

         Name: SaveSP()
             Description: Saves the game to SinglePlayer save file.
             Type: public void

         Name: LoadSP()
             Description: Loads the game from SinglePlayer load file.
             Type: public void

         Name: InitializeItems()
             Description: Initializes items.
             Type: public void

         Name: StartSPBattle(int randomNum)
             Description: Starts SinglePlayer battle, and selects random enemy.
             Type: public void

         Name: StartBattle()
             Description: Starts PvP battle.
             Type: public void

         Name: SwitchWeapon(Player player)
             Description: Switch's the given player's weapon.
             Type: public void

         Name: OpenMainMenu()
             Description: Gives player the option to start a new game or load a previous one.
             Type: public void

         Name: CreateSPCharacters()
             Description: Creates new SinglePlayer character.
             Type: public Player

         Name: CreateCharacters(int playerNum)
             Description: Creates a new PvP player.
             Type: public Player

         Name: ChoosePartner()
             Description: Creates and saves a new partner based on input.
             Type: public void

         Name: SelectLoadout(Player player)
             Description: Gives and saves a loadout based on input.
             Type: public void

         Name: GetInput(out char input, string opt1, string opt2, string query)
             Description: Initializes input variable based on user input
             Type: public void

         Name: GetInput(out char input, string opt1, string opt2, string opt3, string query)
             Description: Initializes input variable based on user input
             Type: public overload void

         Name: ClearScreen()
             Description: Waits for user input, then clears the screen
             Type: public void

         Name: Run()
             Description: Runs the game
             Type: public void

         Name: Start()
             Description: Performed once when the game begins
             Type: public void

         Name: Update()
             Description: Repeated until the game ends
             Type: public void

         Name: End()
             Description: Performed once when the game ends
             Type:public void

**File**: Character.cs

**Attributes**


         Name: Character()
             Description: Initializes Character variables.
             Type: public Constructor

         Name: Character(float health,string name,float damage)
             Description: Initializes Character variables based on arguements.
             Type: public overload Contructor

         Name: Attack(Character enemy)
             Description: Calls & returns TakeDamage on enemy.
             Type: public virtual float

         Name: TakeDamage(float damage)
             Description: Reduces enemy's health by given damage, then returns damage.
             Type: public virtual float

         Name: Heal(Character player)
             Description: Calls & returns GiveHeal on player.
             Type: public virtual float

         Name: GiveHealth(float healing)
             Description: Increases player's health with healing, then returns healing.
             Type: public virtual float

         Name: Save(StreamWriter writer)
             Description: Saves stats, loadout and partner for the player.
             Type: public virtual void

         Name: Load(StreamReader reader)
             Description: Loads stats, loadout and partner for the given player.
             Type: public virtual bool

         Name: GetName()
             Description: Returns name.
             Type: public string

         Name: GetHealth()
             Description: Returns health.
             Type: public bool

         Name: GiveLoadout(int loadout)
             Description: Sets loadout to the given parameter.
             Type: public void

         Name: LoadLoadout(Player player)
             Description: Returns loadout.
             Type: public int

         Name: GivePartner(int partner)
             Description: Sets partner to the given parameter.
             Type: public void

         Name: LoadPartner(Player player)
             Description: Returns partner.
             Type: public int

         Name: PrintStats()
             Description: Prints stats to screen.
             Type: public void

**File**: Player.cs

**Attributes**

         Name: Player() : base()
             Description: Calls default constructor for Player, then calls base classes constructor
             Type: public constructor

         Name: Player(string name, float health, float damage, int inventorySize)
             Description: 
             Type: public overload constructor

         Name: Contains(int itemIndex)
             Description: Checks if itemIndex is longer than the array's length.
             Type: public bool

         Name: AddItemInventory(Item item, int index)
             Description: Adds an item to the array index.
             Type: public void

         Name: GetInventory()
             Description: Returns inventory array.
             Type: public Item[]

         Name: Attack(Character enemy)
             Description: Calls & returns TakeDamage on enemy.
             Type: public override float

         Name: EquipItem(int itemIndex)
             Description: Sets _currentWeapon to selected weapon.
             Type: public void

         Name: UnEquipItem()
             Description: Sets _currentWeapon to _hands.
             Type: public void

         Name: GetSpecialty()
             Description: Returns specialty name.
             Type: public string

         Name: LoadSpecialty()
             Description: Returns number to load specialty.
             Type: public int

         Name: GiveSpecialty(string specialty, int specialtyNum)
             Description: Initializes specialty and specialtyNum.
             Type: public void

         Name: ChangeStats(float health, float damage)
             Description: Sets health and damage to given parameter.
             Type: public void

         Name: PrintSPStats()
             Description: Prints stats for SinglePlayer.
             Type: public void

         Name: SaveSP(StreamWriter writer)
             Description: Saves stats for the player.
             Type: public void

         Name: LoadSP(StreamReader reader)
             Description: Loads stats for the player.
             Type: public bool

**File**: Enemy.cs

**Attributes**

         Name: Enemy()
             Description: 
             Type: public constructor

         Name: Enemy(float health, float damage, string name)
             Description: 
             Type: public overload constructor

         Name: Attack(Character enemy)
             Description: 
             Type: public override float

**File**: Wizard.cs

**Attributes**

         Name: Wizard()
             Description: Calls default constructor for Wizard, then calls base classes constructor.
             Type: public constructor

         Name: Wizard(float health, string name, float damage, float mana)
             Description: 
             Type: public overload constructor

         Name: Attack(Character enemy)
             Description: Calls & returns TakeDamage + damage if Wizard's mana >= 4. else calls base attack function.
             Type: public override float

**File**: Healer.cs

**Attributes**

         Name: Healer()
             Description: Calls default constructor for Healer, then calls base classes constructor.
             Type: public constructor

         Name: Healer(float health, string name, float damage, float mana, float healing)
             Description: 
             Type: public overload constructor

         Name: Heal(Character player)
             Description: Calls & returns GiveHeal + healing if mana >= 8. else calls base Heal function
             Type: public override float
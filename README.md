# Gewoon_Fuji_RPG
CMI INF11B - Gewoon Fuji - Mini Project RPG Game

---------------------------------[FILES]---------------------------------


-------------- Program.CS -------------- 

----- [Classes] -----

-- Program --

// Fields
- n.v.t.

// Methods
- Main




-------------- Player.CS --------------

----- [Classes] -----

-- Player --

// Fields
- CurrentHitPoints
- CurrentLocation
- CurrentWeapon
- MaximumHitPoints
- Name

// Methods
- 




-------------- Monster.CS -------------- 

----- [Classes] -----

-- Monster --

// Fields
- CurrentHitPoints
- ID
- MaximumDamage
- MaximumHitPoints
- Name

// Methods
- 




-------------- World.CS --------------

----- [Classes] -----

-- World --

// Fields
- 

// Methods
- PopulateWeapons
    [SHORT DESCRIPTION]
    parameters: -
    return: void

- PopulateMonsters
    [SHORT DESCRIPTION]
    parameters: -
    return: void

- PopulateQuests
    [SHORT DESCRIPTION]
    parameters: -
    return: void

- PopulateLocations
    [SHORT DESCRIPTION]
    parameters: -
    return: void

- LocationByID
    [SHORT DESCRIPTION]
    parameters: int id
    return: Location (class instance) or null if not found

- WeaponByID
    [SHORT DESCRIPTION]
    parameters: int id
    return: Weapon (class instance) or null if not found

- MonsterByID
    [SHORT DESCRIPTION]
    parameters: int id
    return: Monster (class instance) or null if not found

- QuestByID
    [SHORT DESCRIPTION]
    parameters: int id
    return: Quest (class instance) or null if not found

-------------- Quest.CS -------------- 

----- [Classes] -----

-- Quest --

// Fields
- Description
- ID
- Name

// Methods
- 




-------------- SuperAdventure.CS --------------

----- [Classes] -----

-- SuperAdventure --

// Fields
- CurrentMonster
- ThePlayer

// Methods
- 




-------------- Weapon.CS -------------- 

----- [Classes] -----

// Fields
- ID
- MaximumDamage
- Name

// Methods
- 

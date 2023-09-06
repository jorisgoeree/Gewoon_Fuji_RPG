# Gewoon_Fuji_RPG
CMI INF11B - Gewoon Fuji - Mini Project RPG Game

## Files


### Program.CS

#### Classes

##### Program

**Fields:**
- n.v.t.

**Methods:**
- Main



### Player.CS

#### Classes

##### Player

**Fields:**
- CurrentHitPoints
- CurrentLocation
- CurrentWeapon
- MaximumHitPoints
- Name

**Methods:**
- `Attack`
    - **Description:** Attacks a monster, damage is chance based, calculated based on CurrentWeapon.MaximumDamage with a chance to miss
    - **Parameters:** `Monster` (class instance)
    - **Return:** `int DamageDealt`
- `Move`
    - **Description:** Moves the player if chosen direction is valid
    - **Parameters:** string directionChoice (?? Not sure yet)
    - **Return:** `Location` (?? Not sure yet)


### Monster.CS

#### Classes

##### Monster

**Fields:**
- CurrentHitPoints
- ID
- MaximumDamage
- MaximumHitPoints
- Name

**Methods:**
- `Attack`
    - **Description:** Attacks the player, damage is chance based, from miss to MaximumDamage
    - **Parameters:** `Player` (class instance)
    - **Return:** `int DamageDealt`



### World.CS

#### Classes

##### World

**Fields:**
- (No fields listed)

**Methods:**
- `PopulateWeapons`
    - **Description:** Populates weapons.
    - **Parameters:** None
    - **Return:** void

- `PopulateMonsters`
    - **Description:** Populates monsters.
    - **Parameters:** None
    - **Return:** void

- `PopulateQuests`
    - **Description:** Populates quests.
    - **Parameters:** None
    - **Return:** void

- `PopulateLocations`
    - **Description:** Populates locations.
    - **Parameters:** None
    - **Return:** void

- `LocationByID`
    - **Description:** Get a location by ID.
    - **Parameters:** `int id`
    - **Return:** `Location` (class instance) or null if not found

- `WeaponByID`
    - **Description:** Get a weapon by ID.
    - **Parameters:** `int id`
    - **Return:** `Weapon` (class instance) or null if not found

- `MonsterByID`
    - **Description:** Get a monster by ID.
    - **Parameters:** `int id`
    - **Return:** `Monster` (class instance) or null if not found

- `QuestByID`
    - **Description:** Get a quest by ID.
    - **Parameters:** `int id`
    - **Return:** `Quest` (class instance) or null if not found



### Quest.CS

#### Classes

##### Quest

**Fields:**
- Description
- ID
- Name

**Methods:**
- (No methods listed)



### SuperAdventure.CS

#### Classes

##### SuperAdventure

Controller or manager class, serves as the central point for managing game state, player actions, and interactions with the game world.

**Fields:**
- CurrentMonster (instance of Monster class)
- ThePlayer (instances of player class)

**Methods:**
- (No methods listed)



### Weapon.CS

#### Classes

##### Weapon

**Fields:**
- ID int
- MaximumDamage int
- Name string

**Methods:**
- (No methods listed)

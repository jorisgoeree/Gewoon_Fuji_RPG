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
- (No methods listed)

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
- (No methods listed)

### World.CS

#### Classes

##### World

**Fields:**
- (No fields listed)

**Methods:**
- `PopulateWeapons`
    - **Short Description:** Populates weapons.
    - **Parameters:** None
    - **Return:** void

- `PopulateMonsters`
    - **Short Description:** Populates monsters.
    - **Parameters:** None
    - **Return:** void

- `PopulateQuests`
    - **Short Description:** Populates quests.
    - **Parameters:** None
    - **Return:** void

- `PopulateLocations`
    - **Short Description:** Populates locations.
    - **Parameters:** None
    - **Return:** void

- `LocationByID`
    - **Short Description:** Get a location by ID.
    - **Parameters:** `int id`
    - **Return:** `Location` (class instance) or null if not found

- `WeaponByID`
    - **Short Description:** Get a weapon by ID.
    - **Parameters:** `int id`
    - **Return:** `Weapon` (class instance) or null if not found

- `MonsterByID`
    - **Short Description:** Get a monster by ID.
    - **Parameters:** `int id`
    - **Return:** `Monster` (class instance) or null if not found

- `QuestByID`
    - **Short Description:** Get a quest by ID.
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

**Fields:**
- CurrentMonster
- ThePlayer

**Methods:**
- (No methods listed)

### Weapon.CS

#### Classes

##### Weapon

**Fields:**
- ID
- MaximumDamage
- Name

**Methods:**
- (No methods listed)

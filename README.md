# Space sound

## Software requirements

### 2D gameplay and graphics

- Easier to develop and more likely to fit into our internship time constraints.
- Generally more performant than 3d, which means the project could run smoothly on a wider range of devices.

### Compiles and runs on WebGL using WASM

- Compile once, run everywhere.
- WASM is new faster, smaller and more memory-efficient web runtime.
- People are more likely to play when they do not have to download anything on their machines.
- Ease of distribution through simple link share.

### Short playthrough duration

- Due to our time constraints, it is better to focus on making a short but memorable experience rather than long and somewhat monotonous.
- As most of the testers are not expected to be hardcore players, they might not have enough stamina to play for a longer amount of times. Around 15-20 minutes should work.

## Gameplay description

### Plot

Player has to go trough 3 regions. Each of those regions provides player ship with a new module, and provides obstacles that need to be bypassed using the module. On each of the regions there are several keys that need to be collected by player in order to open a gate towards the next area.

### Region 0: Sun

This is where it starts and ends. Contains 3 gates connected to the 3 regions described below. A transit zone where player can take break between missions.

### Region 1: Nebula

This is stealth level. Player is given a small **searchlight** that allows him to see in a small area in front of him. The task is to collect all the keys whilst avoiding patroling enemies.

### Region 2: Orbits

Ship module: **Thruster**.

The module allows player to perform short distance jumps by applying impulse force. In this area player needs to collect keys while oribiting around wormhole ad resisting its gravitational forces.

### Region 3: Invasion

Ship module: **Cannon**.

This is basic shooting. Player needs to breach enemy defences and pick up keys.

## Internship plan

### Week 1, 3 June - 7 June, gameplay systems

- [x] **Monday**
  
  The first meeting, planning, concept discussion.

- [x] **Tuesday**

  Set up GitHub repo, Unity project. Initial prototype with the visuals and player movement.

- [x] **Wednesday**
  
  Gameplay design description. Winning condition. Ship modules. Gameplay space constraints.

- [x] **Thursday**
  
  Implement level transitions, progression system, region spacial constraints.

- [x] **Friday**.
  
  Player respawn, interrupted transition (UI mock up), region time constraints.

### Week 2, 10 June - 14 June, music systems

- [x] **Monday**
  Nebula region description, assets.

- [x] **Tuesday**
  Nebula region fill, preliminary playtesting.

- [x] **Wednesday**
  Wormhole region description, assets.

- [x] **Thursday**
  Wormhole region fill, preliminary playtesting.

- [x] **Friday**.
  Assault region description, assets.

### Week 3, 17 June - 21 June, analytic systems

- [x] **Monday**
  Assault region fill, preliminary playtesting.

- [x] **Tuesday**
  Overall playtesting, polishing, gameplay bugfixes.

- [ ] **Wednesday**
  Audio framework research.

- [ ] **Thursday**
  Framework preliminary integration.

- [ ] **Friday**.
  Nebula region sound integration, survey.

### Week 4, 24 June - 28 June, player

- [ ] **Monday**
  Wormhole region sound integration, survey.

- [ ] **Tuesday**
  Assault region sound integration, survey.

- [ ] **Wednesday**
  Bugfix, final survey

- [ ] **Thursday**
  Playtesting.

- [ ] **Friday**.
  Playtesting.

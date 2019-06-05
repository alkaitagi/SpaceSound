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

Player has to go trough 3 regions. Each of those regions provides player ship with a new module, and provides obstacles that need to be bypassed using the module. On each of the regions there are several keys that need to be collected by player in order to open a gate towards the next area. After collecting those 3 areas and getting full ship functionality player will be teleproted to the last area. In the last area he will fight a small battle agains simple enemies. Two endings are possible: either player defeats all the enemies and open exit gate, or he is defetead by enemies. None of the endings is to be considered a lose, and we need to convey that feeling of accomplishment to player.

### Region 0: Star

This is where it starts and ends. Contains 3 gates connected to the 3 regions described below. After restoring the star by completing the regions, a small battle will be held.

### Region 1: Nebula

Ship module: light.

Region bounds: asteroid belt.

In this area player has to naviagate trough some sort of maze convered by nebula. Nothing very challenging, just getting used to controls.

### Region 2: Wormhole

Ship module: thruster.

Region bounds: gravity.

The module allows player to perform short distance jumps by applying impulse force. In this area player needs to collect keys while oribiting around wormhole ad resisting its gravitational forces.

### Region 3: Meteors

Ship module: cannon.

Region bounds: orbiting comets.

This is basic shooting. The area is being constaintly exposed to meteorite rain and player needs to destroy some of those meterites to get keys.

## Internship plan

### Week 1, 3 June - 7 June, gameplay systems

- [x] **Monday**
  
  The first meeting, planning, concept discussion.

- [x] **Tuesday**

  Set up GitHub repo, Unity project. Initial prototype with the visuals and player movement.

- [ ] **Wednesday**
  
  Gameplay design description. Winning condition. Ship modules (weapon, engine, light). Gameplay space constraints.

- [ ] **Thursday**
  
  Implement environmental obstacles. Build 3 level zones.

- [ ] **Friday**.
  
  Implement simple enemies. Direct the final battle with two endings. General polishing.

### Week 2, 10 June - 14 June, music systems

- [ ] **Monday**
  
  |

- [ ] **Tuesday**

  |

- [ ] **Wednesday**
  
  |

- [ ] **Thursday**
  
  |

- [ ] **Friday**.
  
  |

### Week 3, 17 June - 21 June, analytic systems

- [ ] **Monday**
  
  |

- [ ] **Tuesday**

  |

- [ ] **Wednesday**
  
  |

- [ ] **Thursday**
  
  |

- [ ] **Friday**.
  
  |

### Week 4, 24 June - 28 June, player

- [ ] **Monday**
  
  |

- [ ] **Tuesday**

  |

- [ ] **Wednesday**
  
  |

- [ ] **Thursday**
  
  |

- [ ] **Friday**.
  
  |

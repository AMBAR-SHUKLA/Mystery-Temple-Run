<div align="center">

# 🏛️ MYSTERY TEMPLE RUN

### *An Endless Runner Through 5 Worlds — Built in Unity 6*

[![Unity](https://img.shields.io/badge/Unity-6000.3.4f1-black?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Mac%20%7C%20Linux-blue?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/AMBAR-SHUKLA/Mystery-Temple-Run)
[![Status](https://img.shields.io/badge/Build_Status-98%25_Complete-brightgreen?style=for-the-badge)](https://github.com/AMBAR-SHUKLA/Mystery-Temple-Run)
[![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)](LICENSE)
[![Developer](https://img.shields.io/badge/Developer-Ambar_Shukla-orange?style=for-the-badge&logo=github)](https://github.com/AMBAR-SHUKLA)

---

> *"Every temple is a door. Every door is a new world."*

---

</div>

## 📖 Overview

**Mystery Temple Run** is a 3D endless runner game built in **Unity 6 LTS** where the player auto-runs through multiple themed worlds, collecting coins and treasure chests while avoiding enemies and obstacles. The core mechanic — **entering a portal gate to be teleported to an entirely new world** — creates a dynamic, multi-world adventure with a unique visual identity per scene.

The game features **5 fully playable worlds** + an overworld (New Earth), a complete coin collection and scoring system, per-world background music, particle effects, and a fully wired teleport system across all scenes.

---

## 🎮 Gameplay Loop

```
Player auto-runs → Collects coins & chests → Avoids enemies & obstacles
        ↓
    Enters Portal Gate
        ↓
Transported to NEW WORLD (speed resets) → Loop continues until death
```

### Controls

| Action | Input |
|--------|-------|
| Move Left / Right | Mouse / Pointer |
| Jump | Left Click (hold for higher jump) |
| Slow Down | Right Click |
| Auto-Run | Automatic (no input needed) |

---

## 🌍 Worlds

### 🏙️ Scene 1 — City Endless Runner
- **Environment:** Urban city road, curved path, tall grass, modern buildings
- **Collectibles:** 7 Basic Coins + 3 Gold Bars + 2 Treasure Chests
- **Obstacles:** Large rock cube, wooden crates, Concrete Barrier, Stop Sign
- **Portal:** Roman stone arch gate (Unique_Stack_A3) → teleports to Scene 2
- **Music:** 🎵 Upbeat urban chase music with percussion

---

### 🏜️ Scene 2 — Desert World
- **Environment:** Sand dunes, desert ruins, stealth bomber & airship overhead
- **Collectibles:** Treasure chests hidden in ruins
- **Obstacles:** Bomb, desert ruins structures, Glass Door
- **Portal:** **Hexagonal stone wall portal with active fire explosion particle** → teleports to Scene 3
- **Music:** 🎵 Tribal drums + wind ambience + ancient mystery tone

---

### ⚓ Scene 3 — Sea Port / Night Docks
- **Environment:** Moonlit cobblestone harbour, candle-lit stone tavern interior, dock planks
- **Collectibles:** 10 Rs Coins (₹), treasure chests, cannonballs on dock planks
- **Obstacles:** Timber Rattlesnake, crates, iron fence, Glass Door
- **Portal:** **Ornate golden arch gate (HD_Arch_1A) with fire cauldrons** → teleports to Scene 4
- **Music:** 🎵 Dark pirate / sea shanty — low strings + wave SFX
- **Special:** Bloom post-process + amber/teal colour grading active

---

### 🚀 Scene 4 — Sci-Fi Spaceship
- **Environment:** Nebula warp tunnel (purple/red/blue skybox), cyan energy rail strips, Earth viewport
- **Collectibles:** Coins along the purple runner path
- **Obstacles:** Speed corridors, ship structure
- **Portal:** **Circular warp ring filling the tunnel cross-section** → teleports to Scene 5
- **Music:** 🎵 Sci-fi electronic ambient — deep bass + synth pad
- **Special:** EarthSimple1 (night-side Earth + city lights) visible through glass viewport

---

### ♟️ Scene 5 — 3D Chess Arena
- **Environment:** Marble and gold chessboard surrounded by a volcanic lava mountain ring
- **Enemies:** Armoured knight chess pieces (patrol)
- **Obstacles:** Chessboard tile zones, knight formations
- **Music:** 🎵 Epic orchestral — grand hall, brass, choir
- **Special:** Final world — reachable through Scene 4 warp ring

---

### 🌏 New Earth — Overworld
- **Environment:** Rolling green hills, volcanic monster terrain landmark (glowing eyes), river, crystal-peak mountains
- **Assets:** Military tanks (Leopard2), gunships, T-Rex, stone tower fortifications, HD_Platform
- **Music:** 🎵 Cinematic orchestral — wide terrain, military ambience
- **Purpose:** Overworld / hub scene — cinematic showcase environment

---

## 🌀 Portal Gates — World Transition System

Each world is connected by a visually distinct portal gate. All portals use:
```csharp
OnTriggerEnter → SceneManager.LoadScene(nextScene) + fade transition + speed reset
```

| From | To | Portal Type |
|------|----|-------------|
| Scene 1 | Scene 2 | Roman stone arch (Unique_Stack_A3) |
| Scene 2 | Scene 3 | **Hexagonal fire portal** — flame + ember particle system |
| Scene 3 | Scene 4 | **Golden ornate arch** (HD_Arch_1A) + fire cauldrons on both sides |
| Scene 4 | Scene 5 | **Circular warp ring** — fills tunnel cross-section, nebula interior |

---

## 💰 Collectibles & Scoring

| Collectible | Behaviour | Value |
|-------------|-----------|-------|
| 10 Rs Coin (₹) | Rotate continuously + glow particle → pickup SFX + score++ | Base |
| Gold Bar | Same as coin, higher point value | Higher |
| Treasure Chest (HarrisChestClips) | Open animation on approach + bonus score | Bonus |

- Coins use **Sphere Collider** with `IsTrigger = true` — `Point Value` field drives score
- Live **HUD Score Counter** updates on Canvas in every scene
- `OnTriggerEnter` destroys coin, plays SFX, and increments score

---

## ⚔️ Obstacles & Enemies

| Type | Examples | Effect |
|------|----------|--------|
| **Enemies** | Mutant patrol, T-Rex, Timber Rattlesnake | Contact = Game Over |
| **Static Hazards** | Rock cube, wooden crate, Concrete Barrier, Stop Sign | Blocks path |
| **Dynamic Hazards** (Planned) | Rolling boulders, waves | Require timing |

- Enemy detection: **Capsule Collider + Enemy tag** → `OnTriggerEnter` ends run
- Player uses `Rigidbody` with **Base Speed** and **Speed Increase** exposed in Inspector

---

## 🎵 Audio System

| Scene | Music Style |
|-------|-------------|
| New Earth | Cinematic orchestral — military ambience |
| Scene 1 City | Upbeat urban chase music with percussion |
| Scene 2 Desert | Tribal drums, wind ambience, ancient mystery tone |
| Scene 3 Port | Dark pirate / sea shanty — low strings, wave SFX |
| Scene 4 Space | Sci-fi electronic ambient — deep bass, synth pad |
| Scene 5 Chess | Epic orchestral — grand hall, brass, choir |
| All Scenes SFX | Coin pickup, chest open, portal whoosh, jump, footstep |

- Per-world `AudioSource` components route through `AudioMixer` for BGM/SFX separation
- Each track **fades in on scene load** and **fades out on exit**

---

## ✨ Visual Effects

| Effect | Location |
|--------|----------|
| Fire + ember particle system (hexagonal portal) | Scene 2 |
| Coin glow / pulsing light emission | All Scenes |
| Candle flame particles (warm point-light) | Scene 3 tavern interior |
| Bloom post-processing | Scenes 3 & 4 |
| Colour grading — amber/teal night palette | Scene 3 |
| Nebula skybox texture (purple/red/blue) | Scene 4 tunnel cylinder |
| Volcanic eyes / lava creature landmark | New Earth overworld |
| FlamesParticleEffect on candle holders | Scene 3 interior |

---

## 🏗️ Technical Architecture

```
Engine           Unity 6 LTS — 6000.3.4f1
Render Pipeline  Built-in Renderer / DX11
Post-Processing  Volume — Bloom + Colour Grading (Scenes 3 & 4)
Teleport System  OnTriggerEnter → SceneManager.LoadScene + fade coroutine
Coin Script      Sphere IsTrigger | PointValue field | Score++
Player Script    BaseSpeed + SpeedIncrease (Inspector-tunable) | Rigidbody
Enemy Script     CapsuleCollider | Enemy Tag | OnTriggerEnter → GameOver
Audio            AudioSource per scene | AudioMixer BGM/SFX routing
VCS              Unity VCS (version controlled)
Total Scenes     7 (GameManager + New Earth + Scene 1–5)
```

---

## 📊 Build Status

| System | Status | Completion |
|--------|--------|------------|
| Scene 1 — City Runner | ✅ Complete | 98% |
| Scene 2 — Desert | ✅ Complete | 98% |
| Scene 3 — Sea Port | ✅ Complete | 99% |
| Scene 4 — Spaceship | ✅ Complete | 97% |
| Scene 5 — Chess Arena | ✅ Complete | 95% |
| New Earth Overworld | ✅ Complete | 95% |
| Auto-Run + Speed Escalation | ✅ Done | 100% |
| Mouse Direction Control | ✅ Done | 100% |
| Jump Mechanic | ✅ Done | 100% |
| Coin Collection + Score HUD | ✅ Done | 100% |
| Treasure Chests | ✅ Done | 100% |
| Teleport / Portal Gates | ✅ Done | 100% |
| Audio / BGM + SFX | ✅ Done | 100% |
| Particle Effects | ✅ Done | 100% |
| Enemy Collision / Game Over | ✅ Done | 95% |
| Procedural Spawner | 🔄 In Progress | 30% |
| Build Export (Windows/Mac) | 🔄 In Progress | 20% |

> **Overall: 98% Complete** — All core gameplay systems implemented and functional.

---

## 📁 Project Structure

```
Mystery-Temple-Run/
├── Assets/
│   ├── Scenes/
│   │   ├── GameManager.unity
│   │   ├── New Earth.unity
│   │   ├── Scean 1.unity            ← City Endless Runner
│   │   ├── Scean 2 Desert.unity     ← Desert World
│   │   ├── Scean 3 port.unity       ← Sea Port / Night Docks
│   │   ├── Scean 4.unity            ← Sci-Fi Spaceship
│   │   └── Scean 5.unity            ← Chess Arena
│   ├── Scripts/
│   │   ├── PlayerController.cs      ← Auto-run, speed escalation, jump
│   │   ├── CoinCollect.cs           ← Trigger, score++, SFX
│   │   ├── EnemyCollision.cs        ← Game-over on contact
│   │   └── SceneTrigger.cs          ← Portal transition + fade
│   ├── Prefabs/
│   ├── Textures/
│   ├── Materials/
│   ├── Audio/
│   └── EffectExamples/
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites
- **Unity 6000.3.4f1 LTS** or later
- Windows / Mac / Linux

### Clone & Run

```bash
# Clone the repository
git clone https://github.com/AMBAR-SHUKLA/Mystery-Temple-Run.git

# Open Unity Hub → Add Project → Select the cloned folder
# Open GameManager scene first, then press ▶ Play
```

### Scene Load Order
```
GameManager → New Earth → Scene 1 (City) → Scene 2 (Desert)
    → Scene 3 (Sea Port) → Scene 4 (Spaceship) → Scene 5 (Chess)
```

---

## 🔮 Roadmap

- [ ] Procedural infinite level spawner (convert static layouts to runtime spawner)
- [ ] Knight L-move obstacle hazard pattern in Chess Arena
- [ ] Full QA playtest across all 5 world transitions
- [ ] Windows build export (primary target)
- [ ] Mac / Linux build export
- [ ] Audio asset compression for smaller build size
- [ ] Barrel mesh polygon fix (resolve DX11 console warning — non-breaking)
- [ ] Rename scene files: `Scean → Scene`

---

## 🎯 Design Pillars

**1. Dynamic Worlds**
Each portal gate leads to a completely different environment — new terrain, music, enemies, and visual atmosphere. No two scenes feel alike.

**2. Progressive Challenge**
Speed gradually increases within each world. Entering a portal resets it, giving a brief moment of relief before the next escalation begins.

**3. Risk-Reward Exploration**
Harder sections of each world place higher-value coins and treasure chests. Players must decide whether to play it safe or push their luck for a higher score.

---

## 👨‍💻 Developer

<div align="center">

| Field | Info |
|-------|------|
| **Name** | Ambar Shukla |
| **Student ID** | 12221174 |
| **University** | Lovely Professional University |
| **Program** | B.Tech CSE — Cybersecurity |
| **Engine** | Unity 6 LTS (6000.3.4f1) |
| **Report Date** | March 26, 2026 |

[![GitHub](https://img.shields.io/badge/GitHub-AMBAR--SHUKLA-black?style=for-the-badge&logo=github)](https://github.com/AMBAR-SHUKLA)

</div>

---

<div align="center">

*Mystery Temple Run — Final Prototype Build · March 2026*

**Ambar Shukla | 12221174 | Lovely Professional University**

[![Star this repo](https://img.shields.io/github/stars/AMBAR-SHUKLA/Mystery-Temple-Run?style=social)](https://github.com/AMBAR-SHUKLA/Mystery-Temple-Run)

</div>

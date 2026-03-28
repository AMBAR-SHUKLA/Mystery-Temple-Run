
<div align="center">

<!-- HERO BANNER -->
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/logo.png" alt="Mystery Temple Run Logo" width="320"/>

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

## 🎮 Gameplay

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
| Auto-Run | Automatic |

---

## 🌍 Worlds

<table>
<tr>
<td align="center" width="33%">

### 🏙️ Scene 1 — City
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/scene1_preview.png" width="260" alt="Scene 1 City"/>

*Urban city road, tall grass, stone arch gates, gold coins & bars, rock obstacles*

🎵 Upbeat urban chase music

</td>
<td align="center" width="33%">

### 🏜️ Scene 2 — Desert
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/scene2_preview.png" width="260" alt="Scene 2 Desert"/>

*Sand dunes, desert ruins, stealth bomber & airship, **hexagonal fire portal***

🎵 Tribal drums + wind ambience

</td>
<td align="center" width="33%">

### ⚓ Scene 3 — Sea Port
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/scene3_preview.png" width="260" alt="Scene 3 Sea Port"/>

*Night docks, cobblestone harbour, candle-lit tavern, **golden arch gate***

🎵 Dark pirate / sea shanty

</td>
</tr>
<tr>
<td align="center" width="33%">

### 🚀 Scene 4 — Sci-Fi Spaceship
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/scene4_preview.png" width="260" alt="Scene 4 Space"/>

*Nebula warp tunnel, cyan energy rails, Earth exterior viewport, **circular warp ring***

🎵 Sci-fi electronic ambient

</td>
<td align="center" width="33%">

### ♟️ Scene 5 — Chess Arena
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/scene5_preview.png" width="260" alt="Scene 5 Chess"/>

*Marble chessboard surrounded by a volcanic lava mountain ring, armoured knight soldiers*

🎵 Epic orchestral — brass, choir

</td>
<td align="center" width="33%">

### 🌏 New Earth — Overworld
<img src="https://raw.githubusercontent.com/AMBAR-SHUKLA/Mystery-Temple-Run/main/Assets/Textures/newearth_preview.png" width="260" alt="New Earth"/>

*Volcanic monster terrain landmark, military tanks & gunships, river fortifications, crystal mountains*

🎵 Cinematic orchestral

</td>
</tr>
</table>

---

## 🌀 Portal Gates — World Transition System

Each world is linked by a **visually distinct portal gate** that triggers `OnTriggerEnter → SceneManager.LoadScene` with a fade transition and speed reset.

| Scene | Portal Type | Effect |
|-------|-------------|--------|
| Scene 1 → 2 | Roman stone arch (Unique_Stack_A3) | Teleports to Desert |
| Scene 2 → 3 | **Hexagonal fire portal** (stone wall + particle flame) | Teleports to Sea Port |
| Scene 3 → 4 | **Golden ornate arch** (HD_Arch_1A + fire cauldrons) | Teleports to Spaceship |
| Scene 4 → 5 | **Circular warp ring** (nebula interior) | Teleports to Chess Arena |

> All portals use `OnTriggerEnter → SceneManager.LoadScene` with fade transition and speed reset.

---

## 💰 Collectibles & Scoring

```
┌─────────────────────────────────────────────────────────┐
│   COLLECTIBLE          │  BEHAVIOUR                     │
├─────────────────────────────────────────────────────────┤
│  10 Rs Coin (₹)        │  Rotate + glow → pickup SFX + score++  │
│  Gold Bar              │  Higher point value, Scene 1 only       │
│  Treasure Chest        │  Open animation + bonus score on touch  │
└─────────────────────────────────────────────────────────┘
```

- Coins use **Sphere Collider** with `IsTrigger = true` — Point Value field drives the score
- Score is shown live on a **HUD Canvas** present in every scene
- `OnTriggerEnter` destroys coin, plays SFX, and increments counter

---

## ⚔️ Obstacles & Enemies

| Type | Examples | Effect |
|------|----------|--------|
| **Enemies** | Mutant patrol, T-Rex, Rattlesnake | Contact = Game Over |
| **Static Hazards** | Rock cube, wooden crate, Concrete Barrier, Stop Sign | Block path |
| **Dynamic Hazards** | Rolling boulder (planned), waves (beach phase) | Require timing |

- Enemy detection uses **Capsule Collider + Enemy tag**
- Player uses `Rigidbody` with exposed **Base Speed** and **Speed Increase** in Inspector

---

## 🎵 Audio System

| Scene | Music Style | SFX |
|-------|-------------|-----|
| New Earth | Cinematic orchestral | Military ambience |
| Scene 1 City | Upbeat urban percussion | Footstep, jump |
| Scene 2 Desert | Tribal drums, ancient wind | Portal whoosh |
| Scene 3 Port | Dark pirate / sea shanty | Wave, candle crackle |
| Scene 4 Space | Sci-fi electronic, synth pad | Deep bass hum |
| Scene 5 Chess | Epic orchestral, brass choir | Grand hall echo |
| All Scenes | — | Coin pickup, chest open, portal whoosh |

Per-world `AudioSource` components route through an `AudioMixer` for BGM/SFX separation. Each track **fades in on scene load** and **fades out on exit**.

---

## ✨ Visual Effects

| Effect | Where Active |
|--------|-------------|
| Fire + ember particles (hexagonal portal) | Scene 2 |
| Coin glow / pulsing light emission | All scenes |
| Candle flame particles (point-lit) | Scene 3 tavern interior |
| Bloom post-processing | Scenes 3 & 4 |
| Colour grading (amber/teal night palette) | Scene 3 |
| Nebula skybox texture (purple/red/blue) | Scene 4 tunnel |
| Volcanic eyes / lava creature feature | New Earth overworld |

---

## 🏗️ Technical Architecture

```
Engine          Unity 6 LTS — 6000.3.4f1
Render Pipeline Built-in Renderer / DX11
Post-Processing URP Volume — Bloom + Colour Grading (Scenes 3 & 4)
Teleport System OnTriggerEnter → SceneManager.LoadScene + fade coroutine
Coin Script     Sphere IsTrigger | PointValue field | Score++
Player Script   BaseSpeed + SpeedIncrease (Inspector-tunable) | Rigidbody
Enemy Script    CapsuleCollider | Enemy Tag | OnTriggerEnter → GameOver
VCS             Unity VCS (version controlled)
Scenes          GameManager + New Earth + Scene 1–5 (7 total)
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
| Coin Collection + Score | ✅ Done | 100% |
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
│   │   ├── Scean 1.unity          ← City Endless Runner
│   │   ├── Scean 2 Desert.unity   ← Desert World
│   │   ├── Scean 3 port.unity     ← Sea Port / Night Docks
│   │   ├── Scean 3 po....unity    ← Port alternate
│   │   ├── Scean 4.unity          ← Sci-Fi Spaceship
│   │   └── Scean 5.unity          ← Chess Arena
│   ├── Scripts/
│   │   ├── PlayerController.cs    ← Auto-run, speed escalation, jump
│   │   ├── CoinCollect.cs         ← Trigger, score++, SFX
│   │   ├── EnemyCollision.cs      ← Game-over on contact
│   │   └── SceneTrigger.cs        ← Portal transition + fade
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
- Unity **6000.3.4f1 LTS** (or later 6.x)
- Windows / Mac / Linux

### Run the Project

```bash
# Clone the repository
git clone https://github.com/AMBAR-SHUKLA/Mystery-Temple-Run.git

# Open in Unity Hub
# File → Open Project → Select cloned folder

# Open GameManager scene first, then press ▶ Play
```

### Scene Load Order
```
GameManager → New Earth → Scene 1 → Scene 2 → Scene 3 → Scene 4 → Scene 5
```

---

## 🗺️ GDD Summary

Mystery Temple Run is designed around three core pillars:

1. **Dynamic Worlds** — Each portal gate leads to a completely different environment with unique terrain, music, enemies, and atmosphere. No two scenes feel alike.

2. **Progressive Challenge** — Player speed gradually increases within each world, raising the difficulty. Entering a portal resets speed, giving a brief moment of relief before the next escalation.

3. **Risk-Reward Exploration** — Harder, riskier sections of each world place higher-value coins and treasure chests. Players must choose whether to play it safe or push their luck for a higher score.

*Target Audience: Ages 10–35 | Casual + Adventure runner fans | PC (Windows, Mac, Linux)*

---

## 🔮 Roadmap

- [ ] Procedural infinite level spawner (modular prefab segments)
- [ ] Knight L-move hazard pattern in Chess Arena
- [ ] Windows build export + QA playtest across all 5 transitions
- [ ] Audio asset compression for smaller build size
- [ ] Barrel mesh polygon fix (resolve DX11 console warning)
- [ ] Rename scene files: `Scean → Scene`

---

## 👨‍💻 Developer

<div align="center">

| | |
|---|---|
| **Name** | Ambar Shukla |
| **Student ID** | 12221174 |
| **University** | Lovely Professional University |
| **Program** | B.Tech CSE — Cybersecurity |
| **Engine** | Unity 6 LTS (6000.3.4f1) |
| **Report Date** | March 26, 2026 |

[![GitHub](https://img.shields.io/badge/GitHub-AMBAR--SHUKLA-black?style=for-the-badge&logo=github)](https://github.com/AMBAR-SHUKLA)

</div>

---

## 📸 Screenshots

> *All screenshots taken from Unity 6 Editor — Scene View*

| Scene 1 — City Runner | Scene 2 — Desert Fire Portal |
|:---:|:---:|
| Player running on city road with coins, gold bars, and stone arch gate visible ahead | Hexagonal stone portal blazing with fire particle explosion — the standout visual of Scene 2 |

| Scene 3 — Sea Port Night Docks | Scene 3 — Candle-Lit Tavern Interior |
|:---:|:---:|
| Moonlit cobblestone harbour with golden arch gate, fire cauldrons, and floating coins | Stone tavern passage with warm candle fire particles, wooden furniture, atmospheric bloom |

| Scene 4 — Nebula Warp Tunnel | New Earth — Overworld |
|:---:|:---:|
| Player silhouette mid-run through sci-fi tunnel, circular warp ring portal ahead, purple nebula skybox | Volcanic monster terrain feature, military fortifications, rolling green hills, crystal-peak mountains |

---

<div align="center">

---

*Mystery Temple Run — Final Prototype Build · March 2026*

**Ambar Shukla | 12221174 | Lovely Professional University**

[![Star this repo](https://img.shields.io/github/stars/AMBAR-SHUKLA/Mystery-Temple-Run?style=social)](https://github.com/AMBAR-SHUKLA/Mystery-Temple-Run)

</div>

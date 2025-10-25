# COMP826_M2
This is a system that provides overview of the situation in a burning building, locates firefighters, and assigns tasks.

## Enviroment Setup
This section ducumented the intial setup process required for the firefighter 3D project.

### 1. Unity installation
**Unity version :**  6000.2.6f1

### 2. IDE Setup
**IDE :**  Visual studio 2022 Community edition
**Development language :**  C#, SQLite, JSON 

### 3. Git repository configuration
**Repo url :**  https://github.com/TheoWang0822/COMP826_M2.git

### 3. Model importation
**Building importation:**   The building model uses modular walls and roofs that can be joined together, which allows control of which floors are shown. PS: All assets are free and open source.

**Release (build / .exe or .apk) :** My project (7).exe

---

## System Overview
- Unity-based 3D fireground overview for mobile/desktop.
- Supports floor show/hide, floor focus view, firefighter/fire highlighting, and a basic task flow (task assignment is planned).

---

## Environment Setup

### 1. Unity installation
**Unity version :** 6000.2.6f1

### 2. IDE Setup
**IDE :** Visual Studio 2022 Community Edition  
**Development language :** C#, SQLite, JSON

### 3. Git repository configuration
**Repo url :** https://github.com/Theowang822/COMP826_M2

### 4. Model importation
**Building importation :** Modular walls and roofs that can be joined together, allowing control of which floors are shown. *(Assets used are free/open source.)*

---

## Quick Start

**Clone Repository :**
```bash
git clone https://github.com/Theowang822/COMP826_M2.git
cd COMP826_M2
```

**Open Unity Project :**
- Open the project folder using **Unity Hub**.  
- Ensure **Unity version is 6000.2.6f1** (Unity Hub will download if missing).

**Import Dependencies :**
- Open **Window → Package Manager** and install:  
  - **DOTween** (Asset Store, free) — camera/UI tween animations  
  - **TextMeshPro** (Unity built-in) — high-quality text rendering  
- After installation, run **Assets → Reimport All** once.

**Run Scene :**
- Open **`Assets/Scenes/SampleScene.unity`**  
- Press **Play** → defaults to **Overview** camera.

**Test Interactions :**
- Click a floor (e.g., **Floor_No_Ceiling (1)**) → camera moves to a parallel side view; click again or wait ~5s to return to **Overview**.  
- Use the **Search Firefighter** field to locate a firefighter; highlights will appear (green = firefighter, red = fire) from **`FireDataSO`**.

---

## Test Data (ScriptableObjects)

All display data are stored locally to demonstrate features (suggested path: `Assets/Data/`). Values can be edited directly in the Inspector.

### 1) Firefighters — `FireFighterListSO`
| **Id** | **Name** | **Status**   | **Location (X,Y,Z)** | **Task** |
|---:|---|---|---|---|
| 11 | James | Available | (1,1,1) | — |
| 22 | Theo  | Busy      | (2,1,1) | — |
| 33 | Carter| Busy      | (1,1,2) | — |
| 44 | Ya    | Busy      | (1,2,3) | — |

### 2) Floors on Fire — `FireDataSO`
- Boolean flags per floor (index 0..4). Example: **Element 1 = true**, **Element 3 = true**, others = false.

### 3) Tasks — `TaskListSO`
| **Description** | **Status (Y/N)** | **Assignee (Id)** |
|---|---|---|
| Rescue A | Y | 11 |
| Rescue B | Y | 22 |
| Rescue C | N | 33 |

> These assets are for demo only. No backend/network dependency.

---

## Core Features

### Building Overview
**Description :** Modular 5-storey building with dynamic show/hide.  
**Key script :** `BuildingController`

### Floor Selection & Camera Control
**Event :** `EventsHub.FloorClicked`  
**Camera :** `CameraController` (DOTween tween to fixed parallel position; Y offset of −2 per floor)

### Firefighter Search & Location
**UI :** Search field (**Search Firefighter**)  
**Data :** `FireDataSO` (ScriptableObject with firefighter & fire data)

### Task Assignment *(Planned)*
**Todo :** Location-aware rescue tasks and path planning.

---

## Project Architecture

**Hierarchy Structure :**
```
SampleScene
├─ Global Volume
├─ BuildingController
├─ CursorController
├─ Floors (Floor_No_Ceiling 1..5)
├─ Main Camera (CameraController)
└─ UIController (Canvas)
   ├─ Search Firefighter Input
   └─ Floor Detail Panel (planned)
```

**Key Scripts :**
- **BuildingController :** floor selection/show-hide, raycast handling  
- **CameraController :** moves between overview and parallel positions  
- **EventsHub :** `public static event Action<Floor> FloorClicked;`  
- **Floor.cs :** floor data model (id, GameObject, etc.)  
- **FireDataSO.cs :** local firefighter/fire data (ScriptableObject)

**Event Flow :**
```
Click floor → Raycast → BuildingController.Select(floor)
→ EventsHub.FloorClicked(floor) → CameraController moves
→ (planned) FloorDetailManager shows UI card
```

---

## How to Modify

### Add a New Floor
**Steps :** Duplicate an existing `Floor_No_Ceiling`, add it to `BuildingController.floorList`, update `CameraController.floorYOffsets`.

### Customize Camera Positions
**Inspector fields :** `overviewPosition`, `baseFloorPosition`, `floorYOffsets`.

---


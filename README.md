# Conway's Game of Life - Unity Project
This project is a Unity-based simulation of Conway's Game of Life. It recreates the famous cellular automaton game where a grid of cells evolves based on simple rules, producing complex and often fascinating patterns over time.

## 📜 About the Game of Life
The Game of Life was devised by mathematician John Conway as a zero-player game. It simulates cellular "life" where cells in a grid live, die, or multiply based on the following rules:

1. **Survival:** Any live cell with 2 or 3 live neighbors remains alive for the next generation.
2. **Death by Underpopulation:** Any live cell with fewer than 2 live neighbors dies.
3. **Death by Overpopulation:** Any live cell with more than 3 live neighbors dies.
4. **Reproduction:** Any dead cell with exactly 3 live neighbors becomes alive.

These simple rules lead to complex and unexpected patterns as the simulation runs.

## 🕹️ Features
This Unity project includes interactive features that allow you to customize and control the simulation:
- **Draw & Erase Cells:**
  - **Left Click:** Draw cells onto the canvas (making them "alive").
  - **Right Click:** Erase cells from the canvas (making them "dead").
  
- **Control Simulation:**
  - **Start and Stop Simulation:** Toggle the simulation on or off at any time.
  - **Adjust Simulation Speed:** Control the pace of evolution.

- **Camera Controls:**
  - **Movement:** Use `W`, `A`, `S`, and `D` to move the camera around the grid.
  - **Zoom:** Use `Q` to zoom in and `E` to zoom out for a better view of the simulation.

## 🎥 Preview
Here's a preview of the simulation in action:
![Game Of Life](https://github.com/user-attachments/assets/93bc2ba9-5174-4cfd-ab20-1c14adafcbb2)

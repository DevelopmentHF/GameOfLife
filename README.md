# Game of Life - Cellular Automaton 🧬

This is an implementation of [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) through Unity and C#.

![logogif](https://user-images.githubusercontent.com/93821760/234017638-2cb64fa3-a629-4f80-aca5-e0f7860d81ce.gif)




---

## Rules
 - Any live cell with two or three live neighbours survives.
 - Any dead cell with three live neighbours becomes a live cell.
 - All other live cells die in the next generation. Similarly, all other dead cells stay dead.


---

## Implementation
These rules were implemented primarily through 2 main C# scripts <br>
There is a grid of Unity GameObjects which are dynamically spawned based on an input resolution from the `player` <br>
At the moment this resolution is capped to 100. <br>
It's also easy to edit the update rate, if you want the game to progress slower or faster. <br>


You can draw, either when the simulation is paused or running for some really cool effects :D .<br>

Visit the itch.io page in the description to play around.

---

## Shader
The cells colour is created through the use of a dynamic shader. <br>
I've made it so the colour of a tile is dependent on the world `x`,`y` position of a tile. <br>
However, this neglects the `z` component of a world space, so I implemented a way to change it via time! <br>
As the simulation progress, a constant colour shift will take place.

---

Proof it works! Gosper's ['gliding gun'](https://en.wikipedia.org/wiki/Gun_(cellular_automaton)) in action.

![GliderGun](https://user-images.githubusercontent.com/93821760/233930237-3e070c6b-c54f-498d-865b-76d7190290f3.gif)

# Game of Life - Cellular Automaton 🧬

This is an implementation of [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) through Unity and C#.

![cgolexplosion](https://user-images.githubusercontent.com/93821760/233937942-6d69d619-74df-43c4-b951-62679e15ff37.gif)



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

---

## Shader
The cells colour is created through the use of a dynamic shader. <br>
I've made it so the colour of a tile is dependent on the world `x`,`y` position of a tile. <br>
However, this neglects the `z` component of a world space, so I implemented a slider to accomodate for this. <br>
This slider allows you to **shift** the z component changing the overall colour space of the tiles, I chose blue for the gif!

---

![GliderGun](https://user-images.githubusercontent.com/93821760/233930237-3e070c6b-c54f-498d-865b-76d7190290f3.gif)

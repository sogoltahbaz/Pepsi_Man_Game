# PepsiMan - Endless Runner Game

A 3D endless runner game built with Unity, featuring the iconic PepsiMan style of gameplay. Navigate through obstacles, manage lanes, and aim for the highest score!

## How to Run the Game
1. Open the project in **Unity Editor** (Version 2021.3 or later recommended).
2. Locate the `Scenes` folder in the Project window.
3. Open the **Main** scene.
4. Press the **Play** button at the top of the Editor to start the game.

## Controls
* **A / Left Arrow:** Move to the Left Lane
* **D / Right Arrow:** Move to the Right Lane
* **R:** Restart the game (when in Game Over screen)

---

## Development Reflection

The development of the PepsiMan runner project was an insightful journey into the core mechanics of 3D endless games. Throughout this process, I focused on creating a seamless loop of gameplay that is both performant and engaging.

### Key Learnings and Features
One of the primary technical milestones was implementing the **Obstacle Spawning System**. Using the `Instantiate` method, I developed a manager that dynamically generates barriers in one of the three lanes ahead of the player. Learning to handle object instantiation while maintaining a stable frame rate was a significant takeaway, leading me to implement a "Destroyer" script to clean up obstacles once they leave the camera's view, ensuring optimal memory management.

For the scoring system, I utilized **PlayerPrefs** to handle persistent data storage. This allowed the game to save the player's high score even after the application was closed, providing a sense of progression and competition.

### Challenges Faced
A major challenge was managing the **Game Over state** and collision detection. Initially, I struggled with the physics interactions between the player and obstacles. I had to ensure that the `Box Collider` on obstacles was set to `Is Trigger` and that the player had a `Rigidbody` component with `Is Kinematic` enabled to accurately detect impacts without causing erratic physics behavior. 

Designing the UI flow to transition smoothly between active gameplay and the Game Over screen required careful **Scene Management**. Handling the game's time scale (`Time.timeScale`) was crucial to pausing the action while allowing the UI buttons to remain interactive. These challenges deepened my understanding of Unity's event lifecycle and physics engine.

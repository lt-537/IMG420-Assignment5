# IMG420-Assignment5
In this project, I have showcased different 2D physic systems inn Godot using C#. The project includes a particle system with custom canvas item shader, a swinging chain system, a laser-beam detecing the player once crossed its path, and a player.

## Particle System
The particle system is implemented using GPUParticles2D used for a floating effect. The shader applies a color gradient effect which the particles will slowly accelerate upward with a wave distortion. It runs continuously in the background, creating a pleasing effect.

## Chain System
The chain system uses a RigidBody2D links, as well as Joint2D joints. I choose to include the properties mass, gravity, and damping to enable the chain to respond realistically. In the case an object (like the player) collides with the chain, it is able to collide, swing, and compress upon contact. 

## Raycast System
This system uses a raycast between points to detect the player as it passes through. If the ray were to hit the player, it would call a detection to trigger an effect (in this case call an alarm).

## Screenshot
<img width="520" height="347" alt="Image" src="https://github.com/user-attachments/assets/e6ebba59-77bf-4e34-80c6-03ef2f0c516c" />

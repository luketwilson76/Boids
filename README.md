## Introduction

In 1986, Craig Reynolds created Boids, an artificial life program that mimics the avian flocking behavior. This was in his paper Flocks, Herds, and Schools: A Distributed Behaviour Model; The term "boid" is short for "bird-oid object," which describes an item that resembles a bird. Boids are an example of emergent behavior and simulate interactions of individual agents following a set of simple rules. "The rules applied to boids are separation, alignment, and cohesion" (Boids, n.d.).

![](https://github.com/luketwilson76/Boids/blob/main/boids.png)

Separation: steer to avoid crowding local flockmates <br />

![](https://github.com/luketwilson76/Boids/blob/main/seperation.gif)

Alignment: steer towards the average heading of local flockmates <br />

![](https://github.com/luketwilson76/Boids/blob/main/alignment.gif)<br />

Cohesion: steer to move towards the average position (center of mass) of local flockmates <br />

![](https://github.com/luketwilson76/Boids/blob/main/cohesion.gif)

More complex rules can be added, such as obstacle avoidance and goal seeking. For my implementation of boids, I created boids that avoid obstacles in a 3D environment using raycasting in Unity3D 2021 written in C#. <br />

Sources: Boids. (n.d.). Wikipedia. Retrieved November 25, 2022, from https://en.wikipedia.org/wiki/Boids <br />

## Boids Script

This script updates the velocity and position of each boid based on the settings that define the characteristics of seperation, alignment, and cohesion plus obstacle avoidance. This script also creates a series of raycast in a unique pattern that allows the boids to navigate 3D spaces smoothly and avoid obastacles. When a raycast detects a clear path, the boid changes direction toward that direction. <br />

Sources: Building Boids in Unity 3D. (2020, January 23). YouTube. Retrieved November 25, 2022, from https://www.youtube.com/watch?v=_d8M3Y-hiUs <br />

## Helper Script

This script is the backbone of the boid's raycasting obstacle avoidance system. This script uses the Fibonacci Sphere Algorithm. This helps create a sphere of raycasts for the boid to use for collision detection."Mapping the Fibonacci Sphere onto the surface of a sphere is an extremely fast and effective approximate method to evenly distribute points"(Roberts, 2020). <br />

Sources:
* Lague, S. (2019, August 26). Coding Adventure: Boids. YouTube. Retrieved November 25, 2022
* from https://www.youtube.com/watch?v=bqtqltqcQhw, Roberts, M. (2020, June 7). How to evenly distribute points on a sphere more effectively than the canonical Fibonacci Lattice. Extreme Learning. Retrieved November 29, 2022, from http://extremelearning.com.au/how-to-evenly-distribute-points-on-a-sphere-more-effectively-than-the-canonical-fibonacci-lattice/ <br />

![](https://github.com/luketwilson76/Boids/blob/main/sphere.png)

## Boid Manager
This script manages the properties of boids using a struct. The properties stored in this script include position, direction, flock heading, center of mass, avoidance heading, and radius in which a boid can detect other boids (perception radius). Some of these properties are updated in the boid script then stored here.<br />

## Boid Settings
This is a scriptable object that allows the user to customize the behaviour of each boid. The user can define these characteristics about the boid.<br />
* min and max speed
* perception radius
* avoiding radius
* steering force
* alignment
* cohesion
* separation
* targeting weight
* bound radius

## Boid Spawner
This script spawns boids in a radius. The user can define the spawn radius and choose how many boids to spawn.<br />

## Conclusion and Discussion
From this project, I was able to learn a lot about agent based models that express the phenomena of emergence. I learned how to successfully create a model of boids that follow the 3 basic rules (seperation, alignment, cohesion). I learned that even though this model has a set of rules, when any variable is changed, it results in boids moving in a random like motion. Though technically nothing is truly random in this model, just random like. I also learned that boids are a great example of emergence and how they model aspects of nature very well. I found it interesting how the model can be modified to represent certain scenerios in nature (e.g., the carrot implementation can represent food and the obstacle implementation can represent predators). I think one of the most interesting things I learned from this project was how to evenly distribute points on a sphere by using the Fibonacci Sphere algorithm (Golden Ratio). Using this, I successfully was able to created a spherical lattice of raycasts that helped my boids navigate and avoid obstacles while maintaing the three rule sof boids resulting in interesting behaviours where boids split in different flocks. I found it interesting on how just putting this ratio in a loop to instantiate raycast at certain angles can create an effective way for agents to navigate environments. I think what I could do better for this project is adding a target for the boids to follow (the carrot). I tried implementing this but was not able to do so successfully. I think all the variables that are already accounted for in the boids behaviour made it difficult to squeeze in more variables that affect their velocity, and the positioning. I think something I would also like to implement in my boid next time is trail renderings. Trail rendering is a visual SFX that can outline the path a boid has taken. I think this could be helpful if I wanted to study the movement patterns of boids visually. <br />

## sources
* Boids. (n.d.). Stanford Computer Science. Retrieved November 22, 2022, from https://cs.stanford.edu/people/eroberts/courses/soco/projects/2008-09/modeling-natural-systems/boids.html
* Boids. (n.d.). Wikipedia. Retrieved November 25, 2022, from https://en.wikipedia.org/wiki/Boids
* Building Boids in Unity 3D. (2020, January 23). YouTube. Retrieved November 25, 2022, from https://www.youtube.com/watch?v=_d8M3Y-hiUs
* Lague, S. (2019, August 26). Coding Adventure: Boids. YouTube. Retrieved November 25, 2022, from https://www.youtube.com/watch?v=bqtqltqcQhw
* Pemmaraju, V. (2013, January 21). 3 Simple Rules of Flocking Behaviors: Alignment, Cohesion, and Separation. Game Development. Retrieved November 22, 2022, from https://gamedevelopment.tutsplus.com/tutorials/3-simple-rules-of-flocking-behaviors-alignment-cohesion-and-separation--gamedev-3444
* Reynolds, C. (1987). Flocks, Herds, and Schools: A Distributed Behavioral Model.
* Roberts, M. (2020, June 7). How to evenly distribute points on a sphere more effectively than the canonical Fibonacci Lattice. Extreme Learning. Retrieved November 29, 2022, from http://extremelearning.com.au/how-to-evenly-distribute-points-on-a-sphere-more-effectively-than-the-canonical-fibonacci-lattice/

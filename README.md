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



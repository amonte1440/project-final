# VR Parkour  
**Anthony Monte**

For my project I want to build a simple [mirror’s edge](https://en.wikipedia.org/wiki/Mirror%27s_Edge) style parkour game where the player has to complete an obstacle course to win the game. I will be extending one of the ideas I had built for the last project which was locomotion via moving the XR controllers in a way that simulates running. There are two features I want to add to this game to make the experience more fluid: jumping and climbing. Thus, the final project will be a VR experience where the player must run, jump, and climb up obstacles to reach the end. If the player falls out of bounds, then the game will restart and they can try again.

## Features

- **Realistic Running**: The current version of the running locomotion doesn’t feel super realistic since the speed of the player doesn’t change based on how quickly the controllers are pumped, so I need to implement it in a way that feels more realistic.  
  - **Estimated Challenge** - 3: I don’t expect this to be too hard since I already have the base logic for this, but I expect implementing some of the math correctly to be challenging.

- **Climbing**: I want the user to be able to “grab” certain objects in the game that will allow them to move based on the direction they are pulling on the object.  
  - **Estimated Challenge** - 5: I only have a rough idea of exactly how I would implement this. I feel like a simple implementation would not be too difficult, but if I want to make it feel realistic, like adding swinging, then it may become difficult to implement.

- **Jumping**: The current version of the running locomotion only allows for movement on one plane. I’d like to incorporate a jumping mechanic to make the game more dynamic.  
  - **Estimated Challenge** - 2: This should be relatively easy to add if the jumping action is performed via a button on the controller. Some care will need to be taken to stop things like double or infinite jumping from being a problem.

## Milestones

- **By 11/19** - Implement the jumping mechanic and a basic version of the climbing mechanic.
- **By 12/5** - Have the realistic running mechanic fully implemented and have the level completely designed and implemented.

## Inspirations

The first inspiration I have is very clear, [Mirror’s Edge](https://en.wikipedia.org/wiki/Mirror%27s_Edge), which is a parkour-style movement game that came out in 2008 and is likely the most iconic and innovative game in the genre. There are a few mechanics that I would like to use as major inspiration for how my own game is going to work in the VR space, specifically the jumping and climbing. If I had extra time, it would be also very interesting to rebuild Mirror’s Edge vaulting mechanics as well.

The other inspiration, [N++](https://store.steampowered.com/app/230270/N_NPLUSPLUS/) (or really the entire N series), is a bit more abstract, but the inspiration I am drawing from this series is how fluid the motion and movement is despite it being a 2D platformer. Right now it seems like a lot of VR games that have tried and tackled the parkour genre don’t focus enough time on really refining the core movement mechanics, leaving them to be a bit jarring. The goal with this project is to spend a lot of time focusing on making those mechanics feel really fluid like N++ and Mirror’s Edge have done for their own mediums.

# unitySandbox
just learning unity, experimenting with stuff here for future projects

So I'm learning unity, and plan to write some 2d platformer games in the future.
It makes sense to have a good design structure and assets prepared beforehand though, so for now 
I'm learning various aspects of game-making and playing with them in this sandbox project.
I really want a nice modular design for my assets: I shouldn't have to rewrite the entire turret code
for AI control vs manual control, and swapping control/faction affiliation/sort of thing should be simple 
and dynamically done.
Also, I really want to get into AI, I have some ideas I want to test out for dynamic decision making and memory 
on the part of AI characters, and it'd be interesting to find out how practical/resource-intensive said ideas would be.

Progress so far:
Interfaces for turret state and action control have been written, and test examples of both have been implemented.
Currently we have three test turrets, you can click on any of them to take manual control. Turrets can be activated, 
deactivated, rotated, and fired.
To do: add example of AI script to track and fire at cursor, switch to AI-control when not manually controlled, 
  include custom sprites for turret/projectiles, and code proper fire-rate/ammunition requirements

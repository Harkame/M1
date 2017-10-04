breed [ lapins lapin]
breed [ loups loup ]

patches-own[odeur]

to setup
  __clear-all-and-reset-ticks
  set-default-shape turtles "bug"

  ask patches
  [
   set odeur 0
  ]

  create-lapins nombre-lapins
  [
    set color blue
    setxy random-xcor random-ycor
    set size 5
  ]

  create-loups nombre-loups
  [
    set color red
    setxy random-xcor random-ycor
    set size 8
  ]
end

to go
  ask lapins[go-lapin]
  diffuse odeur taux-diffusion
  ask patches
  [
    set pcolor scale-color yellow odeur 1 (max-odeur / 1.3)
    set odeur odeur * (100 - 1) / 100
   ]

  ask loups [go-loup]
end

to go-lapin
if odeur < max-odeur
[
 set odeur odeur + 50
 ]
 agiter
 fd 1
end

to go-loup
 follow-odeur
end

to agiter
  rt random 50
  lt random 50
end

to follow-odeur
  ifelse any? neighbors in-radius 5 with [odeur > 0]
  [
    face max-one-of neighbors [odeur]
  ]
  [
    agiter
  ]
  fd 0.8
end

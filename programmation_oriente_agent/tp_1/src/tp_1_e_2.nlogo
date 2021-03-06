breed [lapins-femelles lapin-femelle]
breed [lapins-males lapin-male]
breed [ loups loup ]

patches-own[odeur]

to setup
  __clear-all-and-reset-ticks
  set-default-shape turtles "bug"

  ask patches
  [
   set odeur 0
  ]

  create-lapins-femelles nombre-lapins / 2
  [
    set color pink
    setxy random-xcor random-ycor
    set size 5
  ]

  create-lapins-males nombre-lapins / 2
  [
    set color blue
    setxy random-xcor random-ycor
    set size 5
  ]

  create-loups nombre-loups
  [
    set color red
    setxy random-xcor random-ycor
    set size 10
  ]
end

to go
  ask lapins-femelles[go-lapin-femelle]
  ask lapins-males[go-lapin-male]

  diffuse odeur taux-diffusion
  ask patches
  [
    set pcolor scale-color yellow odeur 1 (max-odeur / 1.3)
    set odeur odeur * (100 - taux-diffusion) / 100
   ]

  ask loups [go-loup]
end

to go-lapin-femelle
 set odeur odeur + 50
 agiter
 fd 1
end

to go-lapin-male
 set odeur odeur + 50
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

to follow-odeur-male
   ifelse any? patches with [odeur > 0 AND pcolor = blue]
  [
    let test max-one-of neighbors [odeur]
    set heading towards test
    fd 1
  ]
  [
    fd 1
    agiter
  ]
end

to follow-odeur-femelle
   ifelse any? patches with [odeur > 0 AND pcolor = pink]
  [
    let test max-one-of neighbors [odeur]
    set heading towards test
    fd 1
  ]
  [
    fd 1
    agiter
  ]
end

to follow-odeur
  ifelse any? patches with [odeur > 0]
  [
    let test max-one-of neighbors [odeur]
    set heading towards test
    fd 0.8
  ]
  [
    fd 0.8
    agiter
  ]
end

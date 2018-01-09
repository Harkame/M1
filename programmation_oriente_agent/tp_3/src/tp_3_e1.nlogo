+breed [lapins-femelles lapin-femelle]
breed [lapins-males lapin-male]
breed [ loups loup ]

patches-own[odeur odeur-male odeur-femelle color-lapin]

to setup
  __clear-all-and-reset-ticks
  set-default-shape turtles "bug"

  ask patches
  [
   set odeur 0
   set odeur-male 0
   set odeur-femelle 0
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
    set pcolor scale-color color-lapin odeur 1 (max-odeur / 1.3)
    set odeur odeur * (100 - taux-diffusion) / 100
    set odeur-male odeur-male * (100 - taux-diffusion) / 100
    set odeur-femelle odeur-femelle * (100 - taux-diffusion) / 100
   ]

  ask loups [go-loup]
end

to go-lapin-femelle
 let target one-of loups  in-radius 3

 ifelse target != nobody
 [
   face target
   rt 180
   fd 3
 ]
 [
   set odeur odeur 50
   set odeur-femelle odeur-femelle 50
   follow-odeur-male
   set color-lapin blue
 ]
end

to go-lapin-male
 let target one-of loups  in-radius 3

 ifelse target != nobody
 [
   face target
   rt 180
   fd 3
 ]
 [
   set odeur odeur 50
   set odeur-male odeur-male 50
   follow-odeur-femelle
   set color-lapin pink
 ]
end

to go-loup
 follow-odeur
end

to agiter
  rt random 50
  lt random 50
end

to follow-odeur-male
   ifelse any? neighbors with [odeur-male > 0]
  [
    face max-one-of neighbors [odeur-male]
  ]
  [
    agiter
  ]
  fd 1
end

to follow-odeur-femelle
  ifelse any? neighbors with [odeur-femelle > 0]
  [
    face max-one-of neighbors [odeur-femelle]
  ]
  [
    agiter
  ]
  fd 1
end

to follow-odeur
  ifelse any? patches with [odeur > 0]
  [
    face max-one-of neighbors [odeur]
  ]
  [
    agiter
  ]
  fd 0.8
end

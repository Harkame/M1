breed [cows cow]
breed [bulls bull]
breed [trucks truck]

patches-own[count_time count_time_init size_plant growing]
cows-own[energy]
trucks-own[energy]

to setup
  __clear-all-and-reset-ticks
  
  set-default-shape cows "cow"
  set-default-shape bulls "cow"
  set-default-shape trucks "truck"
    
  ask patches
  [
    set count_time_init random g_max_time_grow
    set count_time count_time_init
    set size_plant 0 
    set growing true
    
    set pcolor black
   ]
  
  create-cows g_max_count_cows
  [
    set color brown
    setxy random-xcor random-ycor
    set size 3
    set energy 100
  ]
  
  create-bulls g_max_count_cows / 5
  [
    set color red
    setxy random-xcor random-ycor
    set size 5
  ]
  
  create-trucks g_max_count_cows / 7
  [
    set color blue
    setxy random-xcor random-ycor
    set size 5
    set energy 100
  ]
end

to go_patches
  ifelse growing = true
  [
    grow
  ]
  [
    dead
  ]
  
end

to go_turtles
  ask cows[go_cows]
  ask bulls[go_bulls]
  ask trucks[go_trucks]
end

to go_cows
  follow_bull
 
  eat
  set energy energy - 1
  update-plots
end

to go_bulls

  wiggle
 
  eat
  update-plots
end

to go_trucks
  wiggle
  find_cows
      
  set energy energy - 1
  
  update-plots
end

to grow
  ifelse count_time = 0
  [
    set size_plant size_plant 1
    
    set pcolor scale-color green size_plant 0 g_max_size_plant
    
    set count_time count_time_init
    
    if size_plant = g_max_size_plant
    [
      set growing false
    ]
  ]
  [
    set count_time count_time - 1
  ]
end

to dead
  ifelse count_time = 0
  [
    set size_plant size_plant - 1
    
    set pcolor scale-color green size_plant 0 g_max_size_plant
      
    set count_time count_time_init
  
    if size_plant <= 0
    [
      set pcolor black
      set growing true
    ]
  ]
  [
    set count_time count_time - 1
  ]
end

to wiggle
  fd 1
  rt random 50
  lt random 50
end

to eat
  if size_plant > g_consumption
  [
    
    set size_plant size_plant - g_consumption
    
    set energy energy g_consumption
    
    set pcolor scale-color green size_plant 0 g_max_size_plant
      
    set count_time count_time_init
  
    if size_plant = 0
    [
      set pcolor black
      set growing true
    ]
  ]
  
end
 
to follow_bull
  let target min-one-of bulls in-radius 10 [distance myself]
  if target != nobody
  [
    set heading towards target
    fd 1
  ]
end

to find_cows
  let target min-one-of bulls in-radius 10 [distance myself]
  if target != nobody
  [
    set heading towards target
    fd 2
  ]
  
  set target min-one-of cows in-radius 1 [distance myself]
  if target != nobody
  [
    ask target[die]
    
    set energy energy g_consumption
    
    get-away
  ]
end


to get-away
  rt random 360
  fd 20
end

to reproduct
  if
end

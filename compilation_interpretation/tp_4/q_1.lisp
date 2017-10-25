#|
  1. lambda-expressions
|#
((lambda (x) (+ (* 2 x) 3)) 4)

((lambda (x y) (* (+ x 2) (+ y 6))) 7 8)

((lambda (v) ((lambda (x) (* 3 x)) (+ v 2))) 8)

((lambda (v) ((lambda (x) (* v x)) (+ v 2))) 8)

((lambda (v) ((lambda (v) (* 3 v)) (+ v 2))) 8)

((lambda (x y z) (+ (* x y) (* y z))) 2 3 4)

((lambda (x y) (* x x y y)) 4) ; Miss y argument : ((lambda (x y) (* x x y y)) 4 5)

((lambda (x) (* x x 2)) 4 5) ; 1 few argument : ((lambda (x) (* x x 2)) 4)

(lambda (x) (* x x 2)) ; Miss argument : ((lambda (x) (* x x 2)) 6)

#|
  1. fonctions globales
|#
(defun f (x) (+ 3 x))

(defun g (v) (* 5 (f (+ v 2))))

(defun factorial (n)
  (if (= n 1)
    1
    (* n (factorial (- n 1)))
  )
)

(defun fibonacci (n)
  (if (<= n 1)
    1
    (+ (fibonacci(- n 1) (fibonacci(- n 20))))
  )
)

(car '())     ;NIL
(car '(()))   ; NIL
(car '((()))) ; NOT NIL, List with NIL list

(1 2 3 4)     ;4 : (1.(2.(3.(4.NIL))))
(1 (2 3) 4)   ;5 : (1.(((2.(3.NIL)).4)
(1 (2) (3) 4) ;6 : (1.(((2.NIL).(3.NIL).(4.NIL))

(setf l '(1 2 3 4 5 6 7))

(defun mymember (l x)
  (if(eql (car l) x)
    l
    (mymember (cdr l) x)
  )
)

(defun mylength (l)
  (if(eql l NIL)
    0
    (+ 1 (mylength (cdr l)))
  )
)

(defun mylast (l)
  (if(eql (cdr l) NIL)
    (car l)
    (mylast (cdr l))
  )
)

(defun mymakelist (n)
(
  reverse (mymakelistreverse n)
  )
)

(defun mymakelistreverse (n)
  (if(eql n 0)
    NIL
    (cons n (mymakelistreverse (- n 1)))
  )
)

faites une version qui assure qu'un seul test est effectué à chaque pas de la récursion ;
(makelist n) qui crée une liste de longueur n, contenant les entiers de 1 à n, en ordre décroissant ;
et en ordre croissant ?
(copylist l) qui retourne une copie au premier niveau de la liste l ;
(remove x l) qui retourne une copie de la liste l privée des occurrences de x ;
faire la même chose en n'enlevant que la première occurrence de x ;
(append l1 l2) qui concatène 2 listes ;
(adjoin x l) qui "ajoute" x à la liste l si x n'y est pas déjà ;
dans la fonction appelante, que devient l ?

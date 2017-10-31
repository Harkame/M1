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

(setf l1 '(1 2 3 4 5 6 7))
(setf l2 '(42 85 9 4 -4))

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

(defun myremove (x l)
  (if(eql (car l) NIL)
    ()
    (if(eql x (car l))
      (myremove x (cdr l))
      (cons (car l) (myremove x (cdr l)))
    )
  )
)

(defun myremovefirst (x l)
  (myremovefirstaux x l '0)
)

(defun myremovefirstaux (x l count)
  (if(eql (car l) NIL)
    ()
    (if(eql count 1)
      (
        setf count 1
        cons (car l) (myremovefirstaux x (cdr l) count)
      )
      (if (eql x (car l))
        (myremovefirstaux x (cdr l) count)
        (cons (car l) (myremovefirstaux x (cdr l) count))
      )
    )
  )
)





(defun myappend (l1 l2)
     (if (and (eql (cdr l1) NIL) (eql (cdr l2) NIL))
      ()
      ()
     )

    (if (not (eql (cdr l1) NIL))
      (const (car l2) (myappend l1 (cdr l2)))
      ()
    )
)






(defun myappend (l1 l2)
     (if (and (eql (car l1) NIL) (eql (car l2) NIL))
      ()
      (if (and (eql (car l1) NIL) (not (eql (car l2) NIL)))
        (cons (car l2) (myappend l1 (cdr l2)))
        (if (and (not (eql (car l1) NIL)) (not (eql (car l2) NIL)))
          (cons (car l1) (myappend (cdr l1) l2))
        )
      )
     )
)

(defun adjoin (l x)
  adjoinaux(l x NIL)
)

(defun adjoinaux (l x result)
     (if (eql (car l) NIL)
      (x)
      (if(eql (car l) x)
        ()
        (cons (car l) (adjoin (cdr l) x))
      )
    )
)

(adjoin x l) qui "ajoute" x à la liste l si x n'y est pas déjà ;
dans la fonction appelante, que devient l ?

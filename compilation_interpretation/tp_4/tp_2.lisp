(defun mymember (l n &optional  &key ((:test TEST)))
  (if (apply #'TEST (car l) NIL)
    (NIL)
    (if(apply #'TEST (car l) n)
      (t)
      (mymember (cdr l) n)
    )
  )
)

(defun mymember (l n &key ((:test test)))
  (apply #'test NIL n)
)

(mymember l1 n :test #'eql)

(defun calcul (a op b)
  (apply op (list a b))
)

(calcul 9 #'+ 8)

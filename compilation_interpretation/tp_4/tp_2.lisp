(defun mymember (l n &key (test #'eql))
  (if(eql l NIL)
    NIL
    (if(apply test (list (car l) n))
      l
      (mymember (cdr l) n :test test)
    )
  )
)

(defun mymember (l n &key ((:test test)))
  (apply #'test NIL n)
)

(mymember l1 n :test #'eql)

(setf cal '(+ 9 42))

(defun calcul (e)
  (if (atom e)
    e
    (
      apply (car e) (list (nth 2 e) (nth 3 e))
    )
  )
)

(calcul 9 #'+ 8)

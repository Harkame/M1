Section Peano.
Parameter N : Set.
Parameter o : N.
Parameter s : N -> N.
Parameters plus mult : N -> N -> N.
Variables x y : N.
Axiom ax1 : ~((s x) = o).
Axiom ax2 : exists z, ~(x = o) -> (s z) = x.
Axiom ax3 : (s x) = (s y) -> x = y.
Axiom ax4 : (plus x o) = x.
Axiom ax5 : (plus x (s y)) = s (plus x y).
Axiom ax6 : (mult x o) = o.
Axiom ax7 : (mult x (s y)) = (plus (mult x y) x).
End Peano.


(* ex 2 : a la main *) 


Lemma add: (plus (s (s o)) (s (s o))) = (s (s (s (s o)))).

rewrite ax5.
rewrite ax5.
rewrite ax4. 
reflexivity.
Qed.


Lemma  mutl: (mult (s (s o)) (s (s o))) = (s (s (s (s o)))).

rewrite ax7.
rewrite ax7.

rewrite ax5.
rewrite ax5.
rewrite ax5.
rewrite ax5.
rewrite ax4.
rewrite ax4.
rewrite ax6.
reflexivity.
Qed.


(* ex 2 : avec tactique *)

Ltac Peano_tac := 
 intros;
  (repeat
   match goal with
   | |- context[plus ?X o] => rewrite ax4
   | |- context[plus ?X (?S ?Y)] => rewrite ax5
   | |- context[mult ?X o] => rewrite ax6
   | |- context[mult ?X (?S ?Y)] => rewrite ax7
  end).
  
Lemma add_tac: (plus (s (s o)) (s (s o))) = (s (s (s (s o)))).
Peano_tac.
reflexivity.
Qed.

Lemma  mutl_tac: (mult (s (s o)) (s (s o))) = (s (s (s (s o)))).
Peano_tac.
reflexivity.
Qed.

(* ex2 : avec AutoRewrite *) 


Hint Rewrite ax4 ax5 ax6 ax7 : peano.

(* Pas besoin de redefinir les lemmas puisqu'on les enregistre avec 'Qed' *)

Lemma add_auto: (plus (s (s o)) (s (s o))) = (s (s (s (s o)))).
autorewrite with peano using (try reflexivity).
Qed.

Lemma  mutl_auto: (mult (s (s o)) (s (s o))) = (s (s (s (s o)))).
autorewrite with peano using (try reflexivity).
Qed.

(* exercice 1 : logique propositionnel *)

(* 1/ 
Parameter A B: Prop.

Goal A -> B -> A.

intro.
intro.
assumption.

*)

(* 2/

Parameter A B C: Prop.

Goal (A -> B -> C) -> (A -> B) -> A -> C.

intros.
apply (H H1).
apply (H0 H1).

*)

(* 3/ 

Parameter A B: Prop.

Goal A /\ B -> B.

intro.
elim H.
intros.
assumption.

*)

(* 4/ 

Parameter A B: Prop.

Goal B -> A \/ B.

intro.
right.
assumption.

*)

(* 5/ 

Parameter A B C: Prop.

Goal (A \/ B) -> (A -> C) -> (B -> C) -> C.

intros.
elim H.
assumption.
assumption.

*)


(* 6/ 

Parameter A: Prop.

Goal A -> False -> ~A.

intros.
auto.

*)

(* 7/

Parameter A: Prop.

Goal False -> A.

intro.
elim H.

*)

(* 8/

Parameter A B: Prop.

Goal (A <-> B) -> A -> B.

intros.
elim H.
intros.
apply (H1 H0).

*)

(* 9/ 

Parameter A B: Prop.

Goal (A <-> B) -> B -> A.

intros.
elim H.
intros.
apply (H2 H0).

*)

(* 10/ 
Parameter A B: Prop.

Goal (A -> B) -> (B -> A) -> (A <-> B).

intros.
split.
assumption.
assumption.

*)
(* 10bis/ 

Parameter A B: Prop.

Goal (A -> B) -> (B -> A) -> (A <-> B).

tauto.

*)
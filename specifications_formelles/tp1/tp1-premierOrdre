(* Exercice 2 : Logique du premier ordre *)

(* 1/ 
Parameter E: Set.

Parameter P : E -> Prop.
Parameter Q : E -> Prop.

Goal forall x : E, (P x) -> exists y : E, (P y) \/ (Q y).

intros.
exists x.
left.
assumption.

*)

(* 2/ 
Parameter E: Set.
Parameter P Q : E -> Prop.

Goal (exists x : E, (P x) \/ (Q x)) -> (exists x : E, (P x)) \/ (exists x : E, (Q x)).

intros.
elim H.
intros.
elim H0.

intros.
left.
exists x.
assumption.

intros.
right.
exists x.
assumption.

*)


(* 3/ 
Parameter E: Set.
Parameter P Q : E -> Prop.

Goal (forall x : E, (P x)) /\ (forall x : E, (Q x)) -> forall x : E, (P x) /\ (Q x).

intro.
intro.
elim H.
intros.
split.
apply H0.
apply H1.

*)

(* 4/
Parameter E: Set.
Parameter P Q : E -> Prop.

Goal (forall x : E, (P x) /\ (Q x)) -> (forall x : E, (P x)) /\ (forall x : E, (Q x)).

intro.
split.
apply H.
apply H.

*)


(* 5/ 

Parameter E : Set.
Parameter P : E -> Prop.

Goal (forall x : E, ~(P x)) -> ~(exists x : E, (P x)).

intro.
intro.
elim H0.
apply H.

*)

(* 6/ *)

Require Export Classical.

Check NNPP.

Parameter E : Set.
Parameter P : E -> Prop.

Goal ~(forall x : E, (P x)) -> (exists x : E, ~(P x)).

intro.
apply NNPP.
intro.
apply H.
intro.
apply NNPP.
intro.
apply H0.
exists x.
assumption.
(*
Parameter E : Set.

Parameter P Q : E ->Prop.

Goal forall x : E, (P x) -> exists y : E, (P y) \/ (Q y).

intros.

exists x.

left.

assumption.

*)

(*
Parameter E : Set.

Parameter P Q : E ->Prop.

Goal (exists x : E, (P x) \/ (Q x)) -> (exists x : E, (P x)) \/ (exists x : E, (Q x)).

intros.

elim H.

intros.

elim H0.

intros.

left.

exists x.

assumption.

intros;

right.

exists x.

assumption.
*)

(*
Parameter E : Set.

Parameter P Q : E ->Prop.

Goal (forall x : E, (P x)) /\(forall x : E, (Q x)) -> (forall x : E, (P x) /\ (Q x)).

intros.

elim H.

intros.

split.

apply H0.
apply H1.
*)

(*
Parameter E : Set.

Parameter P Q : E ->Prop.

Goal (forall x : E, (P x) /\ (Q x)) -> (forall x : E, (P x)) /\ (forall x : E, (Q x)).

intros.

split.

apply H.

apply H.
*)

(*
Parameter E : Set.

Parameter P Q : E ->Prop.

Goal (forall x : E, ~(P x)) -> ~ (exists x : E, (P x)).

intros.

intro.

elim H0.

apply H.
*)

Require Export Classical.

Check NNPP.

Parameter E : Set.

Parameter P Q : E ->Prop.

Goal ~(forall x : E, (P x)) -> exists x : E, ~ (P x).

intros.

apply NNPP.

intro.

apply H.

intro.

apply NNPP.

intro.

apply H0.

exists x.

apply H1.


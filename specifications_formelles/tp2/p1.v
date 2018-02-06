(*
Parameter A B : Prop.

Goal A -> B -> A.

intros.

apply H.
*)

(*
Parameter A B C : Prop.

Goal (A -> B -> C) -> (A -> B) -> A -> C.

intros.

apply (H H1).

apply (H0 H1).
*)

(*
Parameter A B : Prop.

Goal A /\ B -> B.

intros.

elim H.

intros.

assumption.
*)

(*
Parameter A B : Prop.

Goal B -> A \/ B.

intros.

right.

assumption.
*)

(*
Parameter A B C : Prop.

Goal (A \/ B) -> (A -> C) -> (B -> C) -> C.

intros.

elim H.

assumption.

assumption.
*)

(*
Parameter A B : Prop.

Goal A -> False -> ~A.

intros.

auto.
*)

(*
Parameter A : Prop.

Goal False -> A.

intros.

elim H.
*)

(*
Parameter A B : Prop.

Goal (A <-> B) -> A -> B.

intros.

elim H.

intros.

apply (H1 H0).
*)

(*
Parameter A B : Prop.

Goal (A <-> B) -> B -> A.

intros.

elim H.

intros.

apply H2.

apply H0.
*)

(*
Parameter A B : Prop.

Goal (A -> B) -> (B -> A) -> (A <-> B).

intros.

split.

assumption.

assumption.
*)

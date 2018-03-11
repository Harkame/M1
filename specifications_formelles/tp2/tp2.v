Open Scope type_scope.
Section Iso_axioms.
Variables A B C : Set.
Axiom Com : A * B = B * A.
Axiom Ass : A * (B * C) = A * B * C.
Axiom Cur : (A * B -> C) = (A -> B -> C).
Axiom Dis : (A -> B * C) = (A -> B) * (A -> C).
Axiom P_unit : A * unit = A.
Axiom AR_unit : (A -> unit) = unit.
Axiom AL_unit : (unit -> A) = A.
End Iso_axioms.

(* Exercice 1 : a la main *)

Lemma isos_ex1 :  forall A B : Set,
 A * unit * B = B * (unit * A).

intros.
rewrite (Com unit A).
rewrite Com.
reflexivity.
Qed.


Lemma isos_ex2 : forall A B C:Set,
(A * unit -> B * (C * unit)) =
(A * unit -> (C -> unit) * C) * (unit -> A -> B).

intros.
rewrite (P_unit C).
rewrite (P_unit A).
rewrite (AR_unit C).
rewrite (Com unit C). 
rewrite (P_unit C).
rewrite (Dis).
rewrite (Com).
rewrite (AL_unit (A -> B)).
reflexivity.
Qed.

(* exercice 1 : Avec Tactiques *)

Ltac isos_generic :=
 intros;
   (repeat
      match goal with
      | |- context[?A * unit] => rewrite P_unit
      | |- context[?A -> unit] => rewrite AR_unit
      | |- context[unit -> ?A] => rewrite AL_unit
      | |- context[?A * (?B * ?C)] => rewrite Ass
      | |- context[?A * ?B -> ?C] => rewrite Cur
      | |- context[?A -> ?B * ?C] => rewrite Dis
    end).

Lemma isos_ex1_tactique :  forall A B : Set,
 A * unit * B = B * (unit * A).

isos_generic.
rewrite Com.
reflexivity.
Qed.

Lemma isos_ex2_tactique : forall A B C:Set,
(A * unit -> B * (C * unit)) =
(A * unit -> (C -> unit) * C) * (unit -> A -> B).

isos_generic.
rewrite (Com unit (A -> C)).
rewrite P_unit.
rewrite (Com).
reflexivity.
Qed.

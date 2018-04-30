Require Import FunInd.
Require Import Omega.
Open Scope list_scope.

(* Exercice 1 *)

Parameter E : Set.

Parameter P Q : E ->Prop.

Lemma q1 : (forall x : E, (P x) -> (Q x)) -> (exists x : E, (P x)) -> (exists x : E, (Q x)).
intros.
elim H0.
intros.
exists x.
apply H.
apply H1.
Qed.

Lemma q2 : (((exists x : E, (P x)) \/ (exists x : E, (Q x))) -> exists x : E, (P x) \/ (Q x)).
intros.
elim H.
intros.
elim H0.
intros.
exists x.
left.
apply H1.
intros.
elim H0.
intros.
exists x.
right.
apply H1.
Qed.

(* Exercice 2 *)

Lemma q3 : forall l1 l2 : list E, length (l1++l2) = length l1 + length l2.
intros.
elim l1.
simpl.
reflexivity.
intros.
simpl.
rewrite H.
reflexivity.
Qed.
(* Exercice 3 *)

Inductive is_even : nat -> Prop :=
 | is_even_0 : is_even 0
 | is_even_S : forall n : nat, is_even n -> is_even (S (S n)).

(*
Inductive is_even_list : (list nat) -> Prop :=
  | is_even_list_O : is_even_list nil
  | is_even_list_1 : forall n : nat, is_even n
  | is_even_list_N : forall n : nat, forall l : (list nat), is_even n -> is_even_list(l).
*)

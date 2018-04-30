(* $Id$ *)

(* Exercice 1 *)

Parameter E : Set.
Parameters P Q : E -> Prop.

Lemma prop0 : (forall x, (P x) -> (Q x)) -> (exists x, (P x)) -> exists x, (Q x).
Proof.
  intros.
  elim H0; intros.
  exists x.
  apply (H x).
  assumption.
Qed.

Lemma prop1 : (exists x, (P x)) \/ (exists x, (Q x)) -> exists x, (P x) \/ (Q x).
Proof.
  intro.
  elim H; intro.
  elim H0; intros.
  exists x; left; assumption.
  elim H0; intros.
  exists x; right; assumption.
Qed.

(* Exercice 2 *)

Open Scope list_scope.

Lemma list0 : forall (E : Set) (l l' : list E), length (l++l') = length l + length l'.
Proof.
  double induction l l'; simpl; intros; auto.
  rewrite (H nil); simpl; auto.
  rewrite (H0 (a:: l0)); simpl; auto.
Qed.

(* Exercice 3 *)

Inductive is_even : nat -> Prop :=
| is_even_O : is_even 0
| is_even_S : forall n : nat, is_even n -> is_even (S (S n)).

Inductive is_even_list : list nat -> Prop :=
| is_even_list_nil : is_even_list nil
| is_even_list_cons : forall (n : nat) (l : list nat), is_even n -> is_even_list l -> is_even_list (n :: l).

Lemma ind0 : is_even_list (0::2::4::nil).
Proof.
  apply is_even_list_cons.
  apply is_even_O.
  apply is_even_list_cons.
  apply is_even_S; apply is_even_O.
  apply is_even_list_cons.
  apply is_even_S; apply is_even_S; apply is_even_O.
  apply is_even_list_nil.
Qed.

Lemma ind1 : ~is_even_list (0::1::2::4::nil).
Proof.
  intro.
  inversion H.
  inversion H3.
  inversion H6.
Qed.

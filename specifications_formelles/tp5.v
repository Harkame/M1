Require Import Extraction.
Open Scope list_scope.

Lemma dec_nat : forall a b : nat, {a = b} + {a <> b}.
double induction a b.
left.
reflexivity.

intros.
right.
discriminate.

intros.
right.
discriminate.

intros.
elim (H0 n).

intros.
left.
rewrite a0.
reflexivity.

intros.
right.
congruence.

Defined.

Recursive Extraction dec_nat.

Inductive is_fact : nat -> nat -> Prop :=
  | is_fact_O : is_fact 0 1
  | is_fact_S : forall n : nat, forall s : nat, is_fact n s -> is_fact(S n) (s * (S n)).

Lemma fact : forall n : nat, {v : nat | is_fact n v}.
induction n.
exists 1.
apply is_fact_O.

elim IHn.
intros.
exists (x * S n).
apply is_fact_S.
assumption.
Defined.

Recursive Extraction fact.

Inductive is_map (f : nat -> nat) : (list nat) -> (list nat) -> Prop :=
  | list_nil : is_map f nil nil
  | list_rec : forall (l1 l2 : list nat) (a : nat),
                is_map f l1 l2 ->
                is_map f(a::l1) ((f a) :: l2).

Lemma map (f : nat -> nat) : forall (l : list nat) (a : nat), {l1 : list nat | is_map f l l1}.

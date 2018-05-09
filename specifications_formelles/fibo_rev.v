Require Import FunInd.

Inductive is_fact : nat -> nat -> Prop :=
  | is_fact_O : is_fact 0 1
  | is_fact_S : forall n : nat, forall s : nat, is_fact n s -> is_fact(S n) (s * (S n)).

Fixpoint fact (n : nat) : nat :=
    match n with
      | 0 => 1
      | (S n) => (fact n * (S n))
      end.

Functional Scheme fact_ind := Induction for fact Sort Prop.

Theorem fact_sound:
forall (n : nat) (r : nat), (fact n) = r -> is_fact n r.
Proof.
  intro.
  functional induction (fact n) using fact_ind; intros.
  elim H.
  apply is_fact_O.
  elim H.
  apply is_fact_S.
  apply (IHn0 (fact n0)).
  reflexivity.
  Qed.

Inductive is_fibo : nat -> nat -> Prop :=
  | is_fibo_0 : is_fibo 0 1
  | is_fibo_S : forall n : nat, forall s : nat, is_fibo n s -> is_fibo(S n) (S n + S (S n)).

Fixpoint fibonacci (n:nat) : nat :=
  match n with
    | 0 => 1
    | S 0 => 1
    | S x => fibonacci x + fibonacci (pred x)
end.

Functional Scheme fibo_ind := Induction for fibonacci Sort Prop.

Theorem fibo_sound:
forall (n : nat) (r : nat), (fibonacci n) = r -> is_fibo n r.
intro.
functional induction (fibonacci n) using fibo_ind; intros.
elim H.
apply is_fibo_0.
elim H.
apply is_fibo_S.
apply (IHn0 (fact n0)).
reflexivity.
Qed.
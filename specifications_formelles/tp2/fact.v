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

Require Import FunInd.
Require Import Omega.
Open Scope list_scope.

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

Inductive is_perm : (list nat) -> (list nat)  -> Prop :=
  | is_perm_R : forall l1 : (list nat), is_perm l1 l1
  | is_perm_T : forall l1 l2 l3 : (list nat), is_perm l1 l2 -> is_perm l2 l3 -> is_perm l1 l3
  | is_perm_S : forall l1 l2 : (list nat),  is_perm l1 l2 -> is_perm l2 l1
  | is_perm_C : forall l1 l2 : (list nat),  forall a : nat, is_perm l1 l2 -> is_perm (a::l1) (a::l2)
  | is_perm_A : forall l1 : (list nat),  forall a : nat, is_perm (a :: l1) (l1++ a::nil).

Definition l1  := 1::2::3::nil.
Definition l2 := 3::2::1::nil.
Definition l3 := 2::3::1::nil.

Lemma perma1 : is_perm l1 l2.
unfold l1.
unfold l2.
apply (is_perm_T (1::2::3::nil) ((2::(3::nil))++(1::nil)) (3::2::1::nil)).
apply is_perm_A.
simpl.
apply (is_perm_T (2::3::1::nil) ((3::(1::nil))++(2::nil)) (3::2::1::nil)).
apply is_perm_A.
simpl.
apply is_perm_C.
apply (is_perm_T (1::2::nil) ((1::nil)++(2::nil)) (2::1::nil)).
simpl.
apply is_perm_C.
apply is_perm_R.
apply is_perm_A.
Qed.

Inductive is_sort : (list nat) -> Prop :=
  | is_sort_O : is_sort nil
  | is_sort_1 : forall n : nat, is_sort (n::nil)
  | is_sort_N : forall n m : nat, forall l : (list nat), n <= m -> is_sort(m::l) -> is_sort(n::m::l).

Lemma sort : is_sort l1.
unfold l1.
apply is_sort_N.
omega.
apply is_sort_N.
omega.
apply is_sort_1.
Qed.

Fixpoint insert (l : (list nat)) (n : nat) : (list nat):=
  match l with
    | nil => n::nil
    | h::tl => match le_dec n h with
      | left _ => n::h::tl
      | right _ => h::(insert tl n)
      end
    end.

Fixpoint tri (l : (list nat)) : (list nat) :=
  match l with
    | nil => nil
    | h::t => (insert (tri t) h)
    end.



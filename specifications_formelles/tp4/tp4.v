Require Import FunInd.
Require Import Omega.
Open Scope list_scope.



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

Lemma a : is_sort l1.
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

Fixpoint sort (l : (list nat)) : (list nat) :=
  match l with
    | nil => nil
    | h::t => (insert (sort t) h)
    end.

Theorem yolo:
  forall (l1 l2 : (list nat)), (sort l1) = l2 -> (is_perm l1 l2) /\ is_sort(l2).
Proof.
induction l1.
intros.
split.
simpl in H.
rewrite <- H.
apply is_perm_R.
simpl in H.
rewrite <- H.
apply is_sort_O.



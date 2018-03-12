Lemma Na : forall n: nat, (n * 1) = n.
intros.
elim n.
simpl.
reflexivity.
intros.
simpl.
rewrite H.
reflexivity.
Qed.




Fixpoint f (n : nat) {struct n} : nat :=
 match n with 
 | 0 => 1
 | S p => 2 * (f p)
end.

Lemma f10 : (f 10) = 1024.
simpl.
reflexivity.
Qed.

Require Export List. 
Lemma e3 : forall (E : Type), forall (l : list E), forall (e : E), rev(l ++ e::nil) = e :: rev l.
intros. 
elim l.
simpl.
reflexivity.

intros.
simpl.
rewrite H.
simpl.
reflexivity.
Qed.


Inductive is_even : nat -> Prop :=
 | is_even_0 : is_even 0
 | is_even_S : forall n : nat, is_even n -> is_even (S (S n)).

Ltac is_even :=
 intros;
 (repeat
   apply is_even_S);
   apply is_even_0.

Lemma even2 : is_even 2.
is_even.
Qed.

Ltac isnt_even :=
 intros;
 (repeat
 match goal with
 | H: is_even ?A |-_ => inversion H
 end).

Lemma isnt_even3 : ~is_even 3.
isnt_even.

Inductive is_mod3 : nat -> Prop :=
  | is_mod3_O : is_mod3 0
  | is_mod3_S : forall n : nat, is_mod3 n -> is_mod3 (S (S (S n))).

Ltac is_mod3 :=
  intros;
  (repeat
    apply is_mod3_S);
    apply is_mod3_O.

Lemma mod31 : is_mod3 31.
is_mod3.
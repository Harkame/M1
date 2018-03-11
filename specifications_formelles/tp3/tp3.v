Require Export ZArith.

Open Scope Z_scope.

(* Synthaxe *)
Inductive expr : Set :=
| Cte : Z -> expr
| Plus :  expr-> expr -> expr
| Moins : expr -> expr -> expr
| Mult :  expr -> expr -> expr
| Div :   expr -> expr -> expr.

(* Semantique *)
Inductive eval : expr -> Z -> Prop :=
| ECte : forall c : Z , eval (Cte c) c
| EPlus : forall (e1 e2 : expr) (v v1 v2 : Z),
  eval e1 v1 -> eval e2 v2 -> (v = v1 + v2) -> eval(Plus e1 e2) v
| EMoins : forall (e1 e2 : expr) (v v1 v2 : Z),
  eval e1 v1 -> eval e2 v2 -> (v = v1 - v2) -> eval(Moins e1 e2) (v1 + v2)
| EMult : forall (e1 e2 : expr) (v v1 v2 : Z),
  eval e1 v1 -> eval e2 v2 -> (v = v1 * v2) -> eval(Mult e1 e2) (v1 + v2)
| EDiv : forall (e1 e2 : expr) (v v1 v2 : Z),
  eval e1 v1 -> eval e2 v2 -> (v = v1 / v2) -> eval(Div e1 e2) (v1 + v2).

Definition add1 : expr := (Plus (Cte 1) (Cte 1)).

Lemma example1 : eval add1 2.
eapply EPlus.
eapply ECte.
eapply ECte.
reflexivity.
Qed.

(* TODO : Les autres operatinos *)

Ltac tac :=
  (repeat
    match goal with
      | |- (eval (Plus ?X ?Y) _)  => eapply EPlus
      | |- (eval (Moins ?X ?Y) _) => eapply EMoins
      | |- (eval (Mult ?X ?Y) _)  => eapply EMult
      | |- (eval (Div ?X ?Y) _)   => eapply EDiv
      | |- (eval (Cte  ?X) _)     => eapply ECte
  end);
  auto;
  reflexivity.

Lemma auto_example1 : eval add1 2.
unfold add1.
tac.

(*
Fixpoint f_eval (e : expr) : Z :=
match e with
| Cte c => c
| Plus e1 e2 =>
  let v1 := f_eval e1 in
  let v2 := f_eval e2 in
  v1 + v2
| Moins e1 e2 =>
  let v1 := f_eval e1 in
  let v2 := f_eval e2 in
  v1 - v2
| Mult e1 e2 =>
  let v1 := f_eval e1 in
  let v2 := f_eval e2 in
  v1 * v2
| Div e1 e2 =>
  let v1 := f_eval e1 in
  let v2 := f_eval e2 in
  v1 / v2
end.
*)

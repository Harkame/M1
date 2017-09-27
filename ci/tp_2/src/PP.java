//Les Types :
public abstract class Type
{
  abstract void print();
}

public class Int extends Type
{
  public void print()
  {
    System.out.println("int");
  }
}

public class Bool extends Type
{
  public void print()
  {
    System.out.println("boolean");
  }
}

public class Array extends Type
{
  private Type type;
  public Array(Type t)
  {
    type = t;
  }

  public void print()
  {
    System.out.println("Array of ");
    type.print();
  }
}

//Les Constantes

public abstract class Constante
{
  abstract void print();
}

public  class Number extends Constante
{
  private float value;
  public Number(float n)
  {
    value = n;
  }

  public void print()
  {
    System.out.println(value);
  }
}

public class True extends Constante
{
  private final boolean value = true;

  public void print()
  {
    System.out.println(value);
  }
}

public class False extends Constante
{
  private final boolean value = false;

  public void print()
  {
    System.out.println(value);
  }
}

//Expressions :

abstract class Expr
{
  abstract void print();
}


//Opérateurs Unaires :
public class Inv extends Expr
{
  Expr e;

  public Inv(Expr e)
  {
    this.e = e;
  }

  public void print(){
    println('-');
    e.print();
  }
}
// Opérateurs binaires :
public class Add extends Expr
{
  Expr e1, e2;

  public Add(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('+');
    e2.print();
  }
}

public class Multi extends Expr
{
  Expr e1 ,e2;

  public Multi(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('*');
    e2.print();
  }
}

public class Divide extends Expr
{
  Expr e1 ,e2;

  public Divide(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('/');
    e2.print();
  }
}

public class And extends Expr
{
  Expr e1 ,e2;

  public And(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('AND');
    e2.print();
  }
}

public class Or extends Expr
{
  Expr e1 ,e2;

  public Or(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('OR');
    e2.print();
  }
}

public class Inf extends Expr
{
  Expr e1 ,e2;

  public Inf(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('<');
    e2.print();
  }
}

public class InfEqual extends Expr
{
  Expr e1 ,e2;

  public InfEqual(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('<=');
    e2.print();
  }
}

public class Equal extends Expr
{
  Expr e1 ,e2;

  public Equal(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('=');
    e2.print();
  }
}

public class Dif extends Expr
{
  Expr e1 ,e2;

  public Dif(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('!=');
    e2.print();
  }
}

public class Sup extends Expr
{
  Expr e1 ,e2;

  public Sup(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('>');
    e2.print();
  }
}

public class SupEqual extends Expr
{
  Expr e1 ,e2;

  public SupEqual(Expr e1, Expr e2)
  {
    this.e1 = e1;
    this.e2 = e2;
  }

  public void print(){
    e1.print();
    println('>=');
    e2.print();
  }
}

// Cibles d'appels :

abstract class CallTarget
{
    abstract void print();
}

public class read extends CallTarget
{
  public void print()
  {
    System.out.println("read");
  }
}

public class write extends CallTarget
{
  public void print()
  {
    System.out.println("write");
  }
}

public class Fonction extends CallTarget
{
  private String name;

  public Fonction(String n)
  {
    name = n;
  }

  public void print()
  {
    System.out.println(name);
  }
}

//Expressions

public class Var extends Expr
{
  private String name;

  public Var(String n){
    name = n;
  }
  public void print()
  {
    System.out.print(name);
  }
}

public class Call extends Expr
{
  private CallTarget ca;
  private Expr[] expressions;

  public CallF(CallTarget ca, Expr[] e)
  {
    this.ca = ca;
    expressions = e;
  }

  public void print()
  {
    ca.print();
    System.out.print('(');
    for(int i = 0; i < expressions.length; i++)
    {
      expressions[i].print();
      System.out.print(" ");
    }
      System.out.print(")");
  }
}

public class AccesToIndex
{
  private int index;
  private Var target;

  public AccesToIndex(int i, String n){
    index = i;
    target = n;
  }

  public void print()
  {
    target.print();
    System.out.print("["+index+"]");
  }
}

public class ArrayCreation
{
  private Type type;
  private Expr expression;

  public ArrayCreation(Type t, Expr e)
  {
    type = t;
    expression = e;
  }

  public void print()
  {
    System.out.print("new array of ");
    type.print();
    System.out.print("[");
    expression.print();
    System.out.print("]");
  }
}

//Instructions :

abstract class Instruction
{
  public void print();
}

public class Affectation extends Instruction
{
  private Var var;
  private Expr expression;

  public Affectation(Var v, Expr e)
  {
    var = v;
    expression = e;
  }

  public void print()
  {
    var.print();
    System.out.print(":=");
    expression.print();
  }
}

public class ArrayAffectation extends Instruction
{
  private Var var;
  private Expr index;
  private Expr new_value;

  public Affectation(Var v, Expr e, Expr nv)
  {
    var = v;
    expression = e;
    new_value = nv;
  }

  public void print()
  {
    var.print();
    System.out.print("[");
    index.print();
    System.out.print("]");
    System.out.print(":=");
    new_value.print();
  }
}

//pour if then else 1 seule class ? 

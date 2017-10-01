public abstract class Type
{
	abstract void print();
}

public class Integer extends Type
{
	public void print()
	{
		System.out.println("Integer");
	}
}

public class Boolean extends Type
{
	public void print()
	{
		System.out.println("Boolean");
	}
}

public class Array extends Type
{
	private Type a_type;

	public Array(Type p_type)
	{
		a_type = p_type;
	}

	public void print()
	{
		System.out.println("Array of ");

		a_type.print();
	}
}

public abstract class Constant
{
	abstract void print();
}

public class Number extends Constant
{
	private float a_value;

	public Number(float p_value)
	{
		a_value = p_value;
	}

	public void print()
	{
		System.out.println(a_value);
	}
}

public class True extends Constant
{
	public void print()
	{
		System.out.println("True");
	}
}

public class False extends Constant
{
	public void print()
	{
		System.out.println("False");
	}
}

abstract class Expression
{
	abstract void print();
}

public class Inverse extends Expression
{
	Expression a_expression;

	public Inverse(Expression p_expression)
	{
		a_expression = p_expression;
	}

	public void print()
	{
		System.out.println("-");
		a_expression.print();
	}
}

public class Add extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Add(Expression p_expression_a, Expression p_expression_b)
	{
		a_expression_a = p_expression_a;
		a_expression_b = p_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println("+");

		a_expression_b.print();
	}
}

public class Multiplicate extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Multiplicate(Expression p_expression_a, Expression p_expression_b)
	{
		a_expression_a = p_expression_a;
		a_expression_b = p_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println("*");

		a_expression_b.print();
	}
}

public class Divide extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Divide(Expression p_expression_a, Expression p_expression_b)
	{
		a_expression_a = p_expression_a;
		a_expression_b = p_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println("/");

		a_expression_b.print();
	}
}

public class And extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public And(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println("AND");

		a_expression_b.print();
	}
}

public class Or extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Or(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println("OR");

		a_expression_b.print();
	}
}

public class Inf extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Inf(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println("<");

		a_expression_b.print();
	}
}

public class InfEqual extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public InfEqual(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();
		System.out.println("<=");
		a_expression_b.print();
	}
}

public class Equal extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Equal(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();
		System.out.println("=");
		a_expression_b.print();
	}
}

public class Dif extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Dif(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();
		System.out.println("!=");
		a_expression_b.print();
	}
}

public class Sup extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public Sup(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();

		System.out.println(">");

		a_expression_b.print();
	}
}

public class SupEqual extends Expression
{
	Expression	a_expression_a;
	Expression	a_expression_b;

	public SupEqual(Expression a_expression_a, Expression a_expression_b)
	{
		a_expression_a = a_expression_a;
		a_expression_b = a_expression_b;
	}

	public void print()
	{
		a_expression_a.print();
		System.out.println(">=");
		a_expression_b.print();
	}
}

abstract class CallTarget
{
	abstract void print();
}

public class Read extends CallTarget
{
	public void print()
	{
		System.out.println("Read");
	}
}

public class Write extends CallTarget
{
	public void print()
	{
		System.out.println("Write");
	}
}

public class Fonction extends CallTarget
{
	private String a_name;

	public Fonction(String p_name)
	{
		a_name = p_name;
	}

	public void print()
	{
		System.out.println(a_name);
	}
}

public class Variable extends Expression
{
	private String a_name;

	public Variable(String p_name)
	{
		a_name = p_name;
	}

	public void print()
	{
		System.out.print(a_name);
	}
}

public class Call extends Expression
{
	private CallTarget		a_call_target;
	private Expression[]	a_expressions;

	public Call(CallTarget a_call_target, Expression[] p_expressions)
	{
		a_call_target = a_call_target;
		a_expressions = p_expressions;
	}

	public void print()
	{
		a_call_target.print();

		System.out.print("(");

		for (int i = 0; i < a_expressions.length; i++)
		{
			a_expressions[i].print();
			System.out.print(" ");
		}

		System.out.print(")");
	}
}

public class AccesToIndex
{
	private int			a_index;
	private Variable	a_target;

	public AccesToIndex(int p_index, String p_target)
	{
		a_index = p_index;
		a_target = p_target;
	}

	public void print()
	{
		a_index.print();

		System.out.print("[" + a_target + "]");
	}
}

public class ArrayCreation
{
	private Type		a_type;
	private Expression	a_expression;

	public ArrayCreation(Type p_type, Expression p_expression)
	{
		a_type = p_type;
		a_expression = p_expression;
	}

	public void print()
	{
		System.out.print("new array of ");

		a_type.print();

		System.out.print("[");
		a_expression.print();
		System.out.print("]");
	}
}

abstract class Instruction
{
	public void print();
}

public class Affectation extends Instruction
{
	private Variable	a_variable;
	private Expression	a_expression;

	public Affectation(Variable p_variable, Expression p_expression)
	{
		a_variable = p_variable;
		a_expression = p_expression;
	}

	public void print()
	{
		Variable.print();
		System.out.print(":=");
		a_expression.print();
	}
}

public class ArrayAffectation extends Instruction
{
	private Variable	a_variable;
	private Expression	a_index;
	private Expression	a_new_value;

	public ArrayAffectation(Variable p_variable, Expression p_index, Expression p_new_value)
	{
		a_variable = p_variable;
		a_index = p_index;
		a_new_value = p_new_value;
	}

	public void print()
	{
		a_variable.print();
		System.out.print("[");
		a_index.print();
		System.out.print("]");
		System.out.print(":=");
		a_new_value.print();
	}

}

public static void main(String[] Args)
{
	int i = 2;
}

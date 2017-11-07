package compiler.component.lexer;

public class LexerJava extends AbstractLexer
{
	@Override
	public void lexe(String p_text)
	{
		System.out.println("Lexing Java : " + p_text);
	}
}

// Generated from PP.g4 by ANTLR 4.7
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link PPParser}.
 */
public interface PPListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link PPParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(PPParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link PPParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(PPParser.ExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link PPParser#additionExpr}.
	 * @param ctx the parse tree
	 */
	void enterAdditionExpr(PPParser.AdditionExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link PPParser#additionExpr}.
	 * @param ctx the parse tree
	 */
	void exitAdditionExpr(PPParser.AdditionExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link PPParser#multiplyExpr}.
	 * @param ctx the parse tree
	 */
	void enterMultiplyExpr(PPParser.MultiplyExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link PPParser#multiplyExpr}.
	 * @param ctx the parse tree
	 */
	void exitMultiplyExpr(PPParser.MultiplyExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link PPParser#atomExpr}.
	 * @param ctx the parse tree
	 */
	void enterAtomExpr(PPParser.AtomExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link PPParser#atomExpr}.
	 * @param ctx the parse tree
	 */
	void exitAtomExpr(PPParser.AtomExprContext ctx);
}
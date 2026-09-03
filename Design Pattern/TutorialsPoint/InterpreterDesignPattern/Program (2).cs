// See https://aka.ms/new-console-template for more information
using InterpreterDesignPattern;

// Rule: Robert and John are male
static IExpression getMaleExpression()
{
    IExpression robert = new TerminalExpression("Robert");
    IExpression john = new TerminalExpression("John");
    return new OrExpression(robert, john);
}
// Rule: Julie is a married women
static IExpression getMarriedWomanExpression()
{
    IExpression julie = new TerminalExpression("Julie");
    IExpression married = new TerminalExpression("Married");
    return new AndExpression(julie, married);
}

IExpression isMale = getMaleExpression();
IExpression isMarriedWoman = getMarriedWomanExpression();
Console.WriteLine("John is male? " + isMale.interpret("John"));
Console.WriteLine("Julie is a married woman? " + isMarriedWoman.interpret("Married Julie"));
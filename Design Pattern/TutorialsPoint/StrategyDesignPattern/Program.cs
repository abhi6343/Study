// See https://aka.ms/new-console-template for more information
using StrategyDesignPattern;

Context context = new Context( new OperationAdd() );
Console.WriteLine( "10 + 5 = " + context.executeStrategy(10, 5) );
context = new Context( new OperationSubtract() );
Console.WriteLine( "10 - 5 = " + context.executeStrategy(10, 5) ); 
context = new Context( new OperationMultiply() );
Console.WriteLine( "10 * 5 = " + context.executeStrategy(10, 5) );
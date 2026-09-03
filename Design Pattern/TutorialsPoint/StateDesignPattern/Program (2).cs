// See https://aka.ms/new-console-template for more information
using StateDesignPattern;

Context context = new Context();
StartState startState = new StartState();
startState. doAction ( context ) ;
Console. WriteLine ( context.getState().ToString() ) ;
StopState stopState = new StopState();
stopState. doAction ( context ) ;
Console. WriteLine ( context.getState().ToString() ) ;
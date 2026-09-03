// See https://aka.ms/new-console-template for more information
using ObserverDesignPattern;
using ObserverDesignPattern.Subject;

Subject subject = new Subject();
Observer hexaObserver = new HexaObserver( subject );
new OctalObserver( subject );
new BinaryObserver( subject );

Console.WriteLine( "First state change: 15" );
subject.setState( 15 );
Console.WriteLine( "\nSecond state change: 10" );
subject.setState( 10 );
subject.deattach( hexaObserver );
Console.WriteLine( "\nThird state change: 5" );
subject.setState( 5 );

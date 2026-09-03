using PrintFooBar;

//var p = new FooBarNaive(100);
//var p = new FooBarSemaphoreSlim(100);
//var p = new FooBarMonitor(100);
//var p = new FooBarAutoResetEvent(100);
//var p = new FooBarCondition(100);
//var p = new FooBarYield(100);
var p = new FooBarBarrier(100);
var thread1 = new Thread(p.Foo);
var thread2 = new Thread(p.Bar);
var thread3 = new Thread(p.Baz);
thread1.Start();
Thread.Sleep(10);
thread2.Start();
Thread.Sleep(10);
thread3.Start();
thread1.Join();
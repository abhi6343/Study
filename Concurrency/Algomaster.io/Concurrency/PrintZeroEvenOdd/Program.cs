using PrintZeroEvenOdd;

//var p = new ZeroEvenOddNaive(5);
//var p = new ZeroEvenOddSemaphoreSlim(5);
//var p = new ZeroEvenOddCondition(5);
var p = new ZeroEvenOddMultiCondition(5);
//var p = new ZeroEvenOddLockFree(5);
//var thread1 = new Thread(p.Zero);
//var thread2 = new Thread(p.Odd);
//var thread3 = new Thread(p.Even);
//thread1.Start();
//thread2.Start();
//thread3.Start();
//thread1.Join();
new Thread(p.Zero).Start();
new Thread(p.Odd).Start();
new Thread(p.Even).Start();

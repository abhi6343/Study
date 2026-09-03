using PrintFizzBuzz;

//var p = new FizzBuzzNaive(15);
//var p = new FizzBuzzSemaphoreSlim(15);
//var p = new FizzBuzzCondition(15);
//var p = new FizzBuzzBarrier(15);
var p = new FizzBuzzMultiCondition(15);
new Thread(p.Fizz).Start();
new Thread(p.Buzz).Start();
new Thread(p.FizzBuzz).Start();
new Thread(p.Number).Start();
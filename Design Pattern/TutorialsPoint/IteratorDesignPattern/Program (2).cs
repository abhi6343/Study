// See https://aka.ms/new-console-template for more information
using IteratorDesignPattern;

NameRepository nameRepository = new NameRepository();
for (IIterator iter = nameRepository.getIterator(); iter.hasNext();)
{
    string name = (string)iter.next();
    Console.WriteLine("Name : " + name);
}
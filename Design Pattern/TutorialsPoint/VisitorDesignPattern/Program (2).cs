// See https://aka.ms/new-console-template for more information
using VisitorDesignPattern;

IComputerPart computer = new Computer();
computer.accept( new ComputerPartDisplayVisitor() );
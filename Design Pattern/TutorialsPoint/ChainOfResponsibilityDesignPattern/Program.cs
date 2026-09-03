// See https://aka.ms/new-console-template for more information
using ChainOfResponsibilityDesignPattern;
static AbstractLogger getChainLoggers()
{
    AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
    AbstractLogger fileLogger = new FileLogger(AbstractLogger.DEBUG);
    AbstractLogger consoleLogger = new ConsoleLogger(AbstractLogger.INFO);
    errorLogger.setNextLogger(fileLogger);
    fileLogger.setNextLogger(consoleLogger);
    return errorLogger;
}

AbstractLogger loggerChain  = getChainLoggers();
loggerChain.logMessage(AbstractLogger.INFO, "This is an information.");
Console.WriteLine("");
loggerChain.logMessage(AbstractLogger.DEBUG, "This is a debug level information.");
Console.WriteLine("");
loggerChain.logMessage(AbstractLogger.ERROR, "This is an error information.");
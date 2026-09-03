namespace MultipleInheritanceRealtimeExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HPLaserJetPrinter hPLaserJetPrinter = new HPLaserJetPrinter();
            hPLaserJetPrinter.Scan("Scan Services by HPLaserJetPrinter");
            hPLaserJetPrinter.Print("Print Services by HPLaserJetPrinter");
            hPLaserJetPrinter.Fax("Fax Services by HPLaserJetPrinter");
            hPLaserJetPrinter.PrintDuplex("Print Duplex Services by HPLaserJetPrinter");


            LiquidInkjetPrinter liquidInkjetPrinter = new LiquidInkjetPrinter();
            liquidInkjetPrinter.Scan("Scan Services by LiquidInkjetPrinter");
            liquidInkjetPrinter.Print("Print Services by LiquidInkjetPrinter");
            //Fax and PrintDuplex are not available in LiquidInkjetPrinter
            //liquidInkjetPrinter.Fax("Fax Services");
            //liquidInkjetPrinter.PrintDuplex("Print Duplex Services");


            Console.Read();
        }
    }
}

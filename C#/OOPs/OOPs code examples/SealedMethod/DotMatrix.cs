namespace SealedMethod
{
    //As we marked the InkJet class as sealed so more inheritance using InkJet
    //The following inheritance will give you compile time error
    //'DotMatrix': cannot derive from sealed type 'InkJet'
    //internal class DotMatrix : InkJet
    //{
    //}
}

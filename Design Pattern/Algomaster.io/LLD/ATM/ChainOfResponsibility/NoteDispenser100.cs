using ATM.Entities;

namespace ATM.ChainOfResponsibility
{
    internal class NoteDispenser100(int numNotes) : NoteDispenser(100, numNotes)
    {
    }
}

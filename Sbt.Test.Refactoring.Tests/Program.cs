namespace Sbt.Test.Refactoring.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TractorTest test = new TractorTest();
            
            test.MoveTest();
            test.TurnTest();
            test.TurnAndMoveTest();
            test.SelectionTurn();
            test.TestAddUnit();
        }
    }
}

namespace WordPlay
{
    using System.Collections.Generic;
    using WordPlay.Operations;
    using WordPlay.Transformations;

    
    class Program
    {
       
        static void Main(string[] args)
        {
            var exmapleString = "Tests of [a ([(sample test1)] supplied)] by MeMFIS [Test1 Test2 (test3 test4)]";

            var operationManager = new OperationsManager();
            operationManager.RegisterOperation(new ReverseOperation());
            operationManager.RegisterOperation(new SortOperation());

            var test = new TransformString(operationManager);

            var result = test.TransfromString(exmapleString);

        }
        
        
    }
}

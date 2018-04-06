namespace WordPlay.Operations
{
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Reverse chars operation
    /// </summary>
    public class ReverseOperation : OperationBase
    {
        private const string RegexOpeation = @"\((\w|\d|\s)*\)";

        /// <inheritdoc cref="OperationBase"/>
        public override string RegexString()
        {
            return RegexOpeation;
        }

        /// <inheritdoc cref="OperationBase"/>
        protected override string Operation(string input)
        {
            string local = input.Replace("(", "").Replace(")", "");
            local = new string(local.Reverse().ToArray());
            return local;
        }

        /// <inheritdoc cref="OperationBase"/>
        public override bool HasOpeation(string input)
        {
            return Regex.IsMatch(input, RegexOpeation, RegexOptions.IgnoreCase);
        }


    }
}

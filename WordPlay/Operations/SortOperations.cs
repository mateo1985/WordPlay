namespace WordPlay.Operations
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SortOperation : OperationBase
    {
        private const string RegexOpeation = @"\[(\w|\d|\s)*\]";

        /// <inheritdoc cref="OperationBase"/>
        public override string RegexString()
        {
            return RegexOpeation;
        }

        /// <inheritdoc cref="OperationBase"/>
        public override bool HasOpeation(string input)
        {
            return Regex.IsMatch(input, RegexOpeation, RegexOptions.IgnoreCase);
        }

        /// <inheritdoc cref="OperationBase"/>
        protected override string Operation(string input)
        {
            input = input.Replace("[", string.Empty).Replace("]", "");
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            var result = words.OrderBy(x => x);
            return string.Join(" ", result.ToArray());
        }
    }
}

namespace WordPlay
{
    using WordPlay.Transformations;
    using System.Text.RegularExpressions;

    public abstract class OperationBase : ITransformable
    {
        /// <summary>
        /// Get the regex operation
        /// </summary>
        /// <returns>Returns string with regex</returns>
        public abstract string RegexString();

        /// <summary>
        /// Operation
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Transfromed string</returns>
        protected abstract string Operation(string input);

        /// <summary>
        /// If the string contains an operation to do
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Returns true if has operation to do</returns>
        public abstract bool HasOpeation(string input);

        /// <summary>
        /// Transforms the string
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Returns transfromed string</returns>
        public string Transform(string input)
        {
            var regex = new Regex(this.RegexString());
            var match = regex.Matches(input);

            if (match.Count <= 0)
            {
                return input;
            }

            string local = input;
            for (var i = match.Count - 1; i >= 0; i--)
            {
                string test = this.Operation(match[i].Value);
                local = input.Remove(match[i].Index, match[i].Length).Insert(match[i].Index, test);
            }

            return Transform(local);
        }
    }
}

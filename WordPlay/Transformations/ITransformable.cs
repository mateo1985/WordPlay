namespace WordPlay.Transformations
{
    /// <summary>
    /// Interface for transform operations
    /// </summary>
    public interface ITransformable
    {
        /// <summary>
        /// Check if string has substring with operation to do
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>True if the input string has substring with an operation to do</returns>
        bool HasOpeation(string input);

        /// <summary>
        /// Transforms all substrings with an operation
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Transformed string</returns>
        string Transform(string input);
    }
}

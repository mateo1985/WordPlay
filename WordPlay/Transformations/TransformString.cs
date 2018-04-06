
namespace WordPlay.Transformations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Transforms the string
    /// </summary>
    public class TransformString
    {
        private readonly IOperationsManagable transformationManager;

        /// <summary>
        /// Initializes new instance of TransformString
        /// </summary>
        /// <param name="transformations"></param>
        public TransformString(IOperationsManagable transformationManager)
        {
            this.transformationManager = transformationManager;
        }

        /// <summary>
        /// Transforms the given string
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Returns transformed string</returns>
        public string TransfromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (this.transformationManager == null)
            {
                return input;
            }

            string local = input;
            if (this.HasOperation(input))
            {
                foreach (var i in this.transformationManager)
                {
                    local = i.Transform(local);
                }
            }
            else
            {
                return local;
            }

            return TransfromString(local);
        }

        private bool HasOperation(string input)
        {
            return this.transformationManager.Any(x => x.HasOpeation(input));
        }
    }
}

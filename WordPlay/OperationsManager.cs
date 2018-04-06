using System;
using System.Collections;
using System.Collections.Generic;
using WordPlay.Transformations;

namespace WordPlay
{
    /// <summary>
    /// Manages all transform operations
    /// </summary>
    public class OperationsManager: IOperationsManagable
    {
        private List<ITransformable> operations;

        /// <summary>
        /// Initializes new OperationManager instance
        /// </summary>
        public OperationsManager()
        {
            this.operations = new List<ITransformable>();
        }

        /// <summary>
        /// Registeres new operation transformation
        /// </summary>
        /// <param name="transformable"></param>
        public void RegisterOperation(ITransformable transformable)
        {
            if (transformable == null)
            {
                throw new ArgumentNullException(nameof(transformable));
            }

            this.operations.Add(transformable);
        }

        /// <summary>
        /// Gets enumerator for operations
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ITransformable> GetEnumerator()
        {
            return operations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

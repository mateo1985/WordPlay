namespace WordPlay
{
    using System.Collections.Generic;
    using WordPlay.Transformations;

    /// <summary>
    /// Class should implement this if it manages the transform operations
    /// </summary>
    public interface IOperationsManagable: IEnumerable<ITransformable>
    {
        /// <summary>
        /// Registeres operation
        /// </summary>
        /// <param name="transformable"></param>
        void RegisterOperation(ITransformable transformable);
    }
}

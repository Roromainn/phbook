using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class StorageError:Exception;

    public interface IStorage
    {
        /// <summary>
        /// Create a person
        /// </summary>
        /// <returns>default values</returns>
        IPerson Create();
        /// <summary>
        /// Update the person's info
        /// </summary>
        /// <param name="p">person's values to update</param>
        void Update(IPerson p);
        /// <summary>
        /// Delete the person
        /// </summary>
        /// <param name="p">person to delete</param>
        void Delete(IPerson p);
        /// <summary>
        /// Load the directory
        /// </summary>
        /// <returns>The full directory with infos</returns>
        Directory Load();
    }
}

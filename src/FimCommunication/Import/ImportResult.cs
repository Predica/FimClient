using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;

namespace Predica.FimCommunication.Import
{
    public class ImportResult
    {
        /// <summary>
        /// Objects that were exported. Other objects are only their references.
        /// </summary>
        public IEnumerable<RmResource> PrimaryImportObjects { get; private set; }
        public IEnumerable<RmResource> AllImportedObjects { get; private set; }

        public ImportResult(IEnumerable<RmResource> primaryImportObjects, IEnumerable<RmResource> allImportedObjects)
        {
            PrimaryImportObjects = primaryImportObjects;
            AllImportedObjects = allImportedObjects;
        }
    }
}
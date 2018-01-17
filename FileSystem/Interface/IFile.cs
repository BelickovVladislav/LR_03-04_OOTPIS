using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Interface
{
    public interface IFile : IVFSObject
    {
        /// <summary>
        /// открывает файл
        /// </summary>
        /// <returns></returns>
        string openFile(string path);
    }
}

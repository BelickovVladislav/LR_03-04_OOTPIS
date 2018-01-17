using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Interface
{
    public interface IDirectory : IVFSObject
    {
        /// <summary>
        /// выводит список файлов по пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<String> getListItems(string path);
    }
}

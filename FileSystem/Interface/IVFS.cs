using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Interface
{
    public interface IVFS
    {
        /// <summary>
        /// путь к корню
        /// </summary>
        /// <returns></returns>
        string getHomePath(string path);
        /// <summary>
        /// имя драйвера
        /// </summary>
        /// <returns></returns>
        string getDriverName(string path);
        /// <summary>
        /// используемая файловая система
        /// </summary>
        /// <returns></returns>
        string getFileSystemName(string path);
        /// <summary>
        /// кодировка названия файла
        /// </summary>
        /// <returns></returns>
        string getCodeFileName(string path);
    }
}

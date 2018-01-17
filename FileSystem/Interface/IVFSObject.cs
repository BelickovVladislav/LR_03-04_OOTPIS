using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Interface
{
    public interface IVFSObject
    {
        /// <summary>
        /// переходит к родительской дирректории, на уровень выше
        /// </summary>
        string getParentObject(string path);
        /// <summary>
        /// возвращает инфу об файле или папке
        /// </summary>
        /// <returns></returns>
        string getInfoObject(string path);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Interface;
using System.IO;

namespace FileSystem.FileSystem
{
    public class MyFileSystem: IDirectory, IFile, IVFS
    {
        public DelegateManager.log log;
        private DirectoryInfo directory;
        private StreamReader reader;
        private FileInfo file;
        
        public string openFile(string path)
        {
            reader = new StreamReader(path);
            return reader.ReadToEnd();
        }
        public string getInfoObject(string path)
        {
            if (File.Exists(path))
            {
                file = new FileInfo(path);
                string info = "Это файл\n";
                info += generateInfo("Имя", file.Name);
                info += generateInfo("Полное имя", file.FullName);
                info += generateInfo("Время создания", file.CreationTime.ToString());
                info += generateInfo("Только чтение", file.IsReadOnly.ToString());
                return info;
            }
            if (Directory.Exists(path))
            {
                directory = new DirectoryInfo(path);
                string info = "Это папка\n";
                info += generateInfo("Имя", directory.Name);
                info += generateInfo("Полное имя", directory.FullName);
                info += generateInfo("Время создания", directory.CreationTime.ToString());
                return info;
            }
            return "Ошибка чтения информации.";
        }

        private string generateInfo(string name, string value)
        {
            return name + ": " + value + "\n"; ;
        }

        string IVFS.getHomePath(string path)
        {
            directory = new DirectoryInfo(@"C:/");
            return directory.FullName;
        }

        string IVFS.getDriverName(string path)
        {
            return "инфа о драйверах файловой системы";
        }

        string IVFS.getFileSystemName(string path)
        {
            return "MyFileSystem";
        }

        string IVFS.getCodeFileName(string path)
        {
            file = new FileInfo(path);
            return "UTF-8";
        }

        public List<string> getListItems(string path)
        {
            log.Invoke("Get List file in path: " + path);
            directory = new DirectoryInfo(path);
            List<String> items = new List<String>();
            foreach (var dir in directory.GetDirectories())
            {
                items.Add(dir.Name);
            }
            foreach (var file in directory.GetFiles())
            {
                items.Add(file.Name);
            }
            return items;
        }

        public string getParentObject(string path)
        {
            directory = new DirectoryInfo(path);
            return directory.Parent.FullName;
        }
    }
}

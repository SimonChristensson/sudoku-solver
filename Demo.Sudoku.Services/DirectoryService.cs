using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.Sudoku.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly string _path;
        

        public DirectoryService(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                if (string.IsNullOrEmpty(path))
                    _path = AppDomain.CurrentDomain.BaseDirectory + "/" + "Data";
            }
            else
            {
                _path = path;
            }
        }

        public IEnumerable<string> GetFiles()
        {
            return new DirectoryInfo(_path).GetFiles().Select(d => d.Name);
        }

        public string ReadFile()
        {
            var lines = File.ReadAllText(_path);
            return lines;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Data
{
    public class FileAcessDb
    {
        public static string GetLocalFilePath(string filename)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, filename);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class FilesInfo
    {
        public FileInformation[] Files { get; set; }
        public long TotalSize { get; set; }

        public FilesInfo(FileInformation[] files)
        {
            Files = files;
            TotalSize = 0;
            foreach (FileInformation file in Files)
            {
                TotalSize += file.Size;
            }
        }
    }
}

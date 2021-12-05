using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesInfoController : ControllerBase
    {
        // POST api/FilesInfo
        [HttpPost]
        public FilesInfo Post([FromBody] DirInfo di)
        {
            if (di == null) return null;
            string[] files;
            if (di.Extension == "")
                files = Directory.GetFiles(di.Path);
            else
                files = Directory.GetFiles(di.Path, di.Extension);

            FileInformation[] filesInformation = new FileInformation[files.Length];
            DirectoryInfo d = new DirectoryInfo(di.Path);
            FileInfo[] fis = d.GetFiles();

            for(int i = 0; i < files.Length; i++)
            {
                FileInformation file = new FileInformation();
                file.Name = files[i];
                file.Size = fis[i].Length;
                file.CreationDate = fis[i].CreationTime;
                filesInformation[i] = file;
            }

            FilesInfo filesInfo = new FilesInfo(filesInformation);

            return filesInfo;
        }
        
        [HttpGet]
        public string Get()
        {
            return "It`s work!";
        }
    }
}

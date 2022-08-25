using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Domain.Tools
{
    public static class FileTools
    {
        public static bool ValidaImagem(IFormFile anexo)
        {
            switch (anexo.ContentType)
            {
                case "image/jpeg":
                    return true;
                case "image/bmp":
                    return true;
                case "image/gif":
                    return true;
                case "image/png":
                    return true;
                default:
                    return false;
            }
        }

        public static string SalvarArquivo(string path, IFormFile anexo)
        {
            var nome = Guid.NewGuid().ToString() + anexo.FileName;

            var filePath = path + "\\fotos";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (var stream = System.IO.File.Create(filePath + "\\" + nome))
            {
                anexo.CopyToAsync(stream);
            }

            return nome;
        }
    }
}

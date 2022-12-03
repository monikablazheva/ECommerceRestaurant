using Microsoft.AspNetCore.Http;
using System.IO;
using UserManagementMVCExample.Models;

namespace UserManagementMVCExample.Controllers.Services
{
    public static class ImageUpload
    {
        /*public static void LoadImage(byte[] imageBytes)
        {
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    imageBytes = dataStream.ToArray();
                }
            }
        }*/
    }
}

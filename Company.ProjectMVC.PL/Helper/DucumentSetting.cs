using Microsoft.AspNetCore.Razor.Language;

namespace Company.ProjectMVC.PL.Helper
{
    public static class DucumentSetting
    { 
        public static string Upload(IFormFile file,string folderName)
        {

            //string folderPath = $"C:\\Users\\HP\\Desktop\\Company.ProjectMVC Solution\\Company.ProjectMVC.PL\\wwwroot\\{folderName}";
            //string folderPath=  Directory.GetCurrentDirectory()+ $"\\wwwroot\\{fol PataaaaderName}";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"\\wwwroot\\{folderName}");

            string fileName=$"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(folderPath, fileName);

            var FileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(FileStream);

            return fileName ;



















        }

        public static void Delete (string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"\\wwwroot\\{folderName}",fileName);

            if(File.Exists(filePath) )
            {

            File.Delete(filePath);  
            }


        }
    }
}

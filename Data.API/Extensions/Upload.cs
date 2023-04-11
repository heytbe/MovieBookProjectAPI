using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.API.Extensions
{
    public static class Upload
    {
        public static async Task<string[]> ImageUpload(IFormFile formFile, string DirPath, string DirName)
        {
            string filename = "", fileDir = "", filePath = "";
            DirName = DirName.Trim().Replace(" ", string.Empty);
            DirName = ClearTurkishCharacter(DirName);
            DirName = TextTemizle(DirName);
            if (!Directory.Exists(DirPath + "/Images/Movie/" + DirName))
            {
                Directory.CreateDirectory(DirPath + "/Images/Movie/" + DirName);
            }

            if (formFile != null)
            {
                filename = Path.GetFileNameWithoutExtension(formFile.FileName);
                var extension = Path.GetExtension(formFile.FileName);
                filename = DateTime.Now.ToString("yyssmmffff") + extension;
                fileDir = DirPath + "/Images/Movie/" + DirName +"/";
                var combine = Path.Combine(fileDir, filename);
                using (var file = new FileStream(combine, FileMode.Create))
                {
                    await formFile.CopyToAsync(file);
                }
            }
            filePath = "/Images/Movie/" +DirName+"/"+filename;
            string[] filearray = new string[2]
            {
                filePath,
                Convert.ToString(formFile.Length)
            };

            return filearray;

        }

        public static string ClearTurkishCharacter(string _dirtyText)
        {
            var text = _dirtyText;
            var unaccentedText = String.Join("", text.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark));
            return unaccentedText.Replace("ı", "i");
        }

        public static string TextTemizle(string txt)
        {
            return Regex.Replace(txt, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}

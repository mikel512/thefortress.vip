using NTypewriter.CodeModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Api.Extensions
{
    public class Ext
    {
        public static string ToSnakeCase(string text)
        {
            string[] str = Regex.Split(text, "(?<!^)(?=[A-Z])|[A-Z]([A-Z][a-z])");

            string snake = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                {
                    snake += str[i].ToLower();
                }
                else
                {
                    snake += str[i].ToLower() + "-";
                }
            }
            return snake;

        }
        public static string GenerateLiFromAttr(IAttribute attr, string propCamel, string splitName)
        {

            if (attr.Name == "Required")
            {
                return $@"<li *ngIf=""{propCamel}.errors?.required"">{splitName} field is required </li>";

            }
            else if (attr.Name == "MaxLength")
            {
                return $@"<li *ngIf=""{propCamel}.errors?.maxLength"">Field must have a maximum of  </li>";
            }
            else if (attr.Name == "MinLength")
            {
                return $@"<li *ngIf=""{propCamel}.errors?.maxLength"">Field must have a minimum of</li>";
            }
            else if (attr.Name == "FileExtensions")
            {
                return $@"<li *ngIf=""{propCamel}.errors?.requiredFileType"">File type is not accepted</li>";
            }

            return "";
        }
        public static string Split(string txt)
        {
            var r = @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])";
            string[] str = Regex.Split(txt, r);

            string snake = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                {
                    snake += str[i];
                }
                else
                {
                    snake += str[i] + " ";
                }
            }
            return snake;
        }
    }
}

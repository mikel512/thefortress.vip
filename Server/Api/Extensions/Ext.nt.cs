using NTypewriter.CodeModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;

namespace Api.Extensions
{
    public class Ext
    { 
        public static string GetImports(IClass @class)
        {
            var paramTypes = @class.Methods.Select(x => x.Parameters.Select(t => t.Type)).SelectMany(x => x).ToArray();
            var returnTypes = @class.Methods.Select(x => x.ReturnType).ToArray();

            // filter out types by namespace
            returnTypes = returnTypes.Concat(paramTypes).ToArray();
            returnTypes = returnTypes.Where(x => x.Namespace.EndsWith("Models")).ToArray();

            // filter duplicates
            returnTypes = returnTypes.GroupBy(x => x.Name).Select(g => g.First()).ToArray();

            string result = "";
            foreach(var x in returnTypes)
            {
                result += $"import {{ {x.Name}, I{x.Name} }} from '@models/{ToSnakeCase(x.Name)}'; \n";
            }
            return result;
            //return String.Join(Environment.NewLine,
            //    returnTypes.Select(x => $"import {{ {x.Name}, I{x.Name} }} from '@models/{ToSnakeCase(x.Name)}'; "));
        }

        public static string GetFunctionArgs(string csvParams)
        {
            string[] strings = csvParams.Split(',');
            string result = "";

            for(int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Contains("id")) continue;

                int index = strings[i].IndexOf(':');
                string r = strings[i].Substring(0, index);

                result += (i == strings.Length -1) ? r : r + '\n';

            }

            return result;
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.BLL.Services.Mail
{
    public class EmailTemplateService
    {
        public string LoadTemplate(string templateName)
        {
            var directory = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            var templatePath = Path.Combine(directory,"Areeb.BLL" ,"EmailTemplates", $"{templateName}.html");
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Template {templateName} not found.");

            return File.ReadAllText(templatePath);
        }


        public string ReplacePlaceholders(string template, Dictionary<string, string> placeholders)
        {
            foreach (var placeholder in placeholders)
            {
                template = template.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
            }
            return template;
        }

    }
}

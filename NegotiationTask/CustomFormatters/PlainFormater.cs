using Microsoft.AspNetCore.Mvc.Formatters;
using NegotiationTask.Models;
using System.Text;

namespace NegotiationTask.CustomFormatters
{
    public class PlainFormater : TextOutputFormatter
    {
        public PlainFormater()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var content = context.Object;

            if (content != null)
            {
                var plainTextContent = new StringBuilder();

                foreach (var person in (List<Person>)content)
                {
                    plainTextContent.AppendLine($"Id : {person.Id}");
                    plainTextContent.AppendLine($"Name : {person.Name}");
                    plainTextContent.AppendLine($"Description : {person.Description}");
                    plainTextContent.AppendLine();
                }

                await response.WriteAsync(plainTextContent.ToString(), selectedEncoding);
            }

        }
    }
}

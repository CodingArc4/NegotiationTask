using Microsoft.AspNetCore.Mvc.Formatters;
using NegotiationTask.Models;
using System.Text;

namespace NegotiationTask.CustomFormatters
{
    public class HtmlFormater:TextOutputFormatter
    {
        public HtmlFormater()
        {
            SupportedMediaTypes.Add("text/html");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return typeof(IEnumerable<Person>).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var data = context.Object as IEnumerable<Person>;

            if (data == null)
                return;

            using(var buffer  = new MemoryStream())
            using(var writer = new StreamWriter(buffer, selectedEncoding))
            {
                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html lang=\"en\">");
                writer.WriteLine("<head>");
                writer.WriteLine("<meta charset=\"UTF-8\">");
                writer.WriteLine("<title>Content Negotiation Demo</title>");
                writer.WriteLine("<style>");
                writer.WriteLine("table, th, td { border: 1px solid black; border-collapse: collapse; }");
                writer.WriteLine("th, td { padding: 5px; }");
                writer.WriteLine("</style>");
                writer.WriteLine("</head>");
                writer.WriteLine("<body>");

                var htmlTable = data.ToHtmlTable();

                writer.WriteLine(htmlTable);

                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
                writer.Flush();

                buffer.Position = 0;
                await buffer.CopyToAsync(response.Body);
            }
        }
    }
}
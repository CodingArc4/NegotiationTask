using Microsoft.AspNetCore.Mvc.Formatters;
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

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var content = context.Object.ToString(); 
            return response.WriteAsync(content, selectedEncoding);
        }
    }
}

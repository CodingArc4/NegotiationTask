using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace NegotiationTask.CustomFormatters
{
    public class PlainFormater:TextOutputFormatter
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
                var contentString = content.ToString();
                await response.WriteAsync(contentString, selectedEncoding);
            }
        }

    }
}

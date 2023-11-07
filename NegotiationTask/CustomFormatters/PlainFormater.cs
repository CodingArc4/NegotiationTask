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
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if(typeof(Person).IsAssignableFrom(type)||typeof(IEnumerable<Person>).IsAssignableFrom(type)) {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if(context.Object is IEnumerable<Person>)
            {
                foreach( var persons in ((IEnumerable<Person>)context.Object) )
                {
                    PlainText(buffer,persons);
                }
            }
            else
            {
                PlainText(buffer, (Person)context.Object);
            }
            await response.WriteAsync(buffer.ToString());          
        }

        private static void PlainText(StringBuilder builder,Person person)
        {
            builder.AppendLine($"Id : {person.Id}");
            builder.AppendLine($"Name : {person.Name}");
            builder.AppendLine($"Description : {person.Description}");
            builder.AppendLine();
        }
    }
}

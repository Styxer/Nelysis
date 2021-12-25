using Nelysis.Services.Interfaces;

namespace Nelysis.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}

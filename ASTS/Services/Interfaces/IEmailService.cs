using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string recipentMail, string subject, string body);
    }
}

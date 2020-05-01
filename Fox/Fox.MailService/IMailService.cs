using Fox.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fox.MailServices
{
    public interface IMailService
    {
        Task SendMail(PurchaseModel pm);
    }
}

using IDTPDomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDTPAdminUI.Models
{
    public class TransactionMonitorViewModel
    {
        public TransactionRequestLog transactionRequestLog;
        public decimal Amount { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusLibrary
{
    public class Finance
    {
        public string Account { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardCvv { get; set; }
        public string Iban { get; set; }
    }
}

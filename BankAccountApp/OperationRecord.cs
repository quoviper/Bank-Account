using System;

namespace BankAccountApp
{
   public class OperationRecord
   {
        public string Type { get; set; }
        public decimal? Amount { get; set; }
        public DateTime DateTime { get; set; }
        public override string ToString() => $"{DateTime}: {Type}{(Amount.HasValue ? "  |  " + Amount.Value.ToString("C") : "")}";
    }
}

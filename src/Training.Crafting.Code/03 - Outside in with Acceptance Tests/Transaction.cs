using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Training.Crafting.Code.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Training.Crafting.Code.Accounts
{

    internal class Transaction
    {
        public DateTime Date { get; }
        public int Amount { get; }

        public Transaction(
            DateTime date,
            int amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}

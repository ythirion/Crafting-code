using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;
using Training.Crafting.Code.Accounts;
using Xunit;

namespace Training.Crafting.Code.Tests.Accounts
{
    public class PrintStatementFeature
    {
        private IConsole console;

        public PrintStatementFeature()
        {
            console = A.Fake<IConsole>();
        }

        [Fact]
        public void print_statement_containing_transactions_in_reverse_chronological_order()
        {
            AccountService accountService = new AccountService(
                new TransactionFactory(),
                new TransactionRepository()
                );

            accountService.Deposit(1000);
            accountService.Withdraw(100);
            accountService.Deposit(500);

            accountService.PrintStatement();

            A.CallTo(() => console.Print("DATE       | AMOUNT  | BALANCE")).MustHaveHappened()
                .Then(A.CallTo(() => console.Print("10/04/2014 | 500.00  | 1400.00")).MustHaveHappened())
                .Then(A.CallTo(() => console.Print("02/04/2014 | -100.00 | 900.00")).MustHaveHappened())
                .Then(A.CallTo(() => console.Print("01/04/2014 | 1000.00 | 1000.00")).MustHaveHappened());
        }
    }
}
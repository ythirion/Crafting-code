using FakeItEasy;
using System;
using Training.Crafting.Code.Accounts;
using Xunit;

namespace Training.Crafting.Code.Tests.Accounts
{
    public class AccountServiceShould
    {
        private AccountService accountService;
        private ITransactionFactory transactionFactory;
        private ITransactionRepository transactionRepository;

        public AccountServiceShould()
        {
            transactionFactory = A.Fake<ITransactionFactory>();
            transactionRepository = A.Fake<ITransactionRepository>();
            accountService = new AccountService(
                transactionFactory,
                transactionRepository
            );
        }

        [Fact]
        public void store_a_positive_transaction_on_deposit()
        {
            
            var amountToDepose = 500;
            var createdTransaction = new Transaction(DateTime.Now, amountToDepose);

            A.CallTo(() => transactionFactory.Create(amountToDepose))
                .Returns(createdTransaction);

            accountService.Deposit(amountToDepose);

            A.CallTo(() => transactionFactory.Create(amountToDepose)).MustHaveHappened(Repeated.Exactly.Once)
                .Then(A.CallTo(() => transactionRepository.Save(createdTransaction)).MustHaveHappened(Repeated.Exactly.Once));
        }

        [Fact]
        public void store_a_negative_transaction_on_withdraw_when_balance_is_over_withdraw_amount()
        {
            var amountToWithdraw = 100;
            var accountBalance = 101;
            var createdTransaction = new Transaction(DateTime.Now, amountToWithdraw);

            A.CallTo(() => transactionFactory.Create(-amountToWithdraw)).Returns(createdTransaction);
            A.CallTo(() => transactionRepository.GetBalance()).Returns(accountBalance);

            accountService.Withdraw(amountToWithdraw);

            A.CallTo(() => transactionRepository.GetBalance()).MustHaveHappened(Repeated.Exactly.Once)
                .Then(A.CallTo(() => transactionFactory.Create(-amountToWithdraw)).MustHaveHappened(Repeated.Exactly.Once))
                .Then(A.CallTo(() => transactionRepository.Save(createdTransaction)).MustHaveHappened(Repeated.Exactly.Once));
        }

        [Fact]
        public void raise_a_not_enough_money_exception()
        {
            var amountToWithdraw = 100;
            var accountBalance = 10;
            var createdTransaction = new Transaction(DateTime.Now, amountToWithdraw);

            A.CallTo(() => transactionRepository.GetBalance()).Returns(accountBalance);

            accountService.Withdraw(amountToWithdraw);

            A.CallTo(() => transactionRepository.GetBalance()).MustHaveHappened(Repeated.Exactly.Once)
                .Then(A.CallTo(() => transactionFactory.Create(-amountToWithdraw)).MustHaveHappened(Repeated.Exactly.Once))
                .Then(A.CallTo(() => transactionRepository.Save(createdTransaction)).MustHaveHappened(Repeated.Exactly.Once));
        }
    }
}

namespace Training.Crafting.Code.Accounts
{
    internal class AccountService
    {
        private ITransactionFactory _transactionFactory;
        private ITransactionRepository _transactionRepository;

        public AccountService(
            ITransactionFactory transactionFactory,
            ITransactionRepository transactionRepository)
        {
            _transactionFactory = transactionFactory;
            _transactionRepository = transactionRepository;
        }

        public void Deposit(int amount)
        {
            var transaction = _transactionFactory.Create(amount);
            _transactionRepository.Save(transaction);
        }

        public void Withdraw(int amount)
        {
            if (IsAllowedToWithdraw(amount))
            {
                var transaction = _transactionFactory.Create(-amount);
                _transactionRepository.Save(transaction);
            }
        }

        private bool IsAllowedToWithdraw(int amount)
        {
            return amount < _transactionRepository.GetBalance();
        }

        public void PrintStatement()
        {

        }
    }
}

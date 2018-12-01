namespace Training.Crafting.Code.Accounts
{
    internal interface ITransactionRepository
    {
        void Save(Transaction createdTransaction);
        int GetBalance();
    }
}
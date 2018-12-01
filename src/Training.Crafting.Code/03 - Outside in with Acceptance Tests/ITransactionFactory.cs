namespace Training.Crafting.Code.Accounts
{
    internal interface ITransactionFactory
    {
        Transaction Create(int amount);
    }
}
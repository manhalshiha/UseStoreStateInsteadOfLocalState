namespace UseStoreStateInsteadOfLocalState.Stores.CounterStore
{
    public class DecrementAction:IAction
    {
        public const string Decrement = "Decrement";

        public string Name => Decrement;
    }
}

namespace UseStoreStateInsteadOfLocalState.Stores.CounterStore
{
    public class IncrementAction:IAction
    {
        public const string Increment = "Increment";

        public string Name => Increment;
        public int Count { get; set; }
    }
}

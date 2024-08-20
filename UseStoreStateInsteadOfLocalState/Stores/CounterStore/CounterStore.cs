namespace UseStoreStateInsteadOfLocalState.Stores.CounterStore
{
    //MyMainProcess
    public class CounterState
    {
        public int Count { get; }
        public CounterState(int Count)
        {
            this.Count = Count;
        }

    }
    public class CounterStore
    {
        private CounterState _state;
        private readonly IActionDispatcher actionDispatcher;
        public CounterStore(IActionDispatcher actionDispatcher)
        {
            _state = new CounterState(0);
            this.actionDispatcher = actionDispatcher;
            //This line of code is subscribing to the action dispatcher. This means that the HandleActions method will be called whenever an action is dispatched. The HandleActions
            // method is responsible for handling the action and performing the necessary operations.
            this.actionDispatcher.Subscript(HandleActions);
        }
        //~CounterStore()
        //{
        //    this.actionDispatcher.Unsubscript(HandleActions);
        //}
        public void HandleActions(IAction action)
        {
            switch (action.Name)
            {
                case IncrementAction.Increment:
                    IncrementCount();
                    break;
                case DecrementAction.Decrement:
                    DecrementCount();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Gets the current state of the counter, by create instace from CounterStore class
        /// </summary>
        /// <returns>The current state of the counter.</returns>
        public CounterState GetState()
        {
            return _state;
        }
        private void IncrementCount()
        {
            var count = this._state.Count;
            count++;
            this._state = new CounterState(count);
            BroadCastStateChange();
        }
        private void DecrementCount()
        {
            var count = this._state.Count;
            count--;
            this._state = new CounterState(count);
            BroadCastStateChange();
        }
        #region Observer pattern
        private Action _listners;


        public void AddStateChangeListners(Action listner)
        {
            _listners += listner;
        }
        public void RemoveStateChangeListners(Action listner)
        {
            _listners -= listner;
        }
        public void BroadCastStateChange()
        {
            _listners.Invoke();
        }

        #endregion
    }
}

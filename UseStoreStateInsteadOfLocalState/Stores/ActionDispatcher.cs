

using UseStoreStateInsteadOfLocalState.Stores.CounterStore;

namespace UseStoreStateInsteadOfLocalState.Stores
{
    //This class is an implementation of the IActionDispatcher interface. It provides methods for subscribing and unsubscribing to action handlers, as well as a method
    // for dispatching an action. The _registeredActionHandlers field is used to store the registered action handlers, and the Subscript and Unsubscript methods are used
    // to add and remove action handlers from the list. The Dispatch method is used to invoke the registered action handlers with the given action.
    public class ActionDispatcher : IActionDispatcher
    {
        private Action<IAction> _registeredActionHandlers;
       public void Subscript(Action<IAction> actionHandler) => _registeredActionHandlers += actionHandler;
       public void Unsubscript(Action<IAction> actionHandler) => _registeredActionHandlers -= actionHandler;
        public void Dispatch(IAction action) => _registeredActionHandlers?.Invoke(action);
    }
}

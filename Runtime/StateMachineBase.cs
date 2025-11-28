#if STATE_MACHINE_BASE_ENABLED
using System;
using Stateless;
using Stateless.Graph;

namespace Marmary.StateBehavior
{
    /// <summary>
    ///     Base class for state machines
    /// </summary>
    /// <typeparam name="TState"> State enum </typeparam>
    /// <typeparam name="TTrigger"> Trigger enum </typeparam>
    public abstract class StateMachineBase<TState, TTrigger> where TState : Enum where TTrigger : Enum
    {
        #region Fields

        /// <summary>
        ///     State machine
        /// </summary>
        protected readonly StateMachine<TState, TTrigger> StateMachine;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the current state managed by the state machine.
        /// </summary>
        public TState CurrentState => StateMachine.State;

        #endregion

        #region Constructors and Injected

        /// <summary>
        ///     State machine basic configuration
        /// </summary>
        /// <param name="initialState"></param>
        protected StateMachineBase(TState initialState)
        {
            StateMachine = new StateMachine<TState, TTrigger>(initialState);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Generates a DOT graph representation of the state machine.
        ///     Useful for visualizing the state machine's structure.
        /// </summary>
        /// <returns>A string containing the DOT graph representation of the state machine.</returns>
        public string ToDotGraph()
        {
            return UmlDotGraph.Format(StateMachine.GetInfo());
        }

        /// <summary>
        ///     Fires a trigger to transition the state machine to the next state.
        /// </summary>
        /// <param name="trigger">The trigger to fire.</param>
        public virtual void FireTrigger(TTrigger trigger)
        {
            StateMachine.Fire(trigger);
        }

        /// <summary>
        ///     Checks whether the supplied trigger can be fired from the current state.
        /// </summary>
        /// <param name="trigger">Trigger to evaluate.</param>
        /// <returns><c>true</c> if the trigger is valid in the current state.</returns>
        public bool CanFire(TTrigger trigger)
        {
            return StateMachine.CanFire(trigger);
        }


        /// <summary>
        ///     Configures the state machine
        /// </summary>
        protected abstract void ConfigureStateMachine();

        #endregion
    }
}
#endif
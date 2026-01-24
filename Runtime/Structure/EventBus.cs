using System;
using DTT.ExtendedDebugLogs;
using MessagePipe;
using VContainer;

namespace Marmary.Utils.Runtime.Structure
{
    /// <summary>
    ///     Interface for an event bus that allows publishing and subscribing to messages of a specific type.
    /// </summary>
    public interface IEventBus
    {
        #region Methods

        /// <summary>
        ///     Publishes a message to all subscribers of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the message to publish.</typeparam>
        /// <param name="message">The message to publish.</param>
        void Publish<T>(T message);

        /// <summary>
        ///     Subscribes to messages of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the message to subscribe to.</typeparam>
        /// <param name="handler">The action to execute when a message is received.</param>
        /// <returns>An IDisposable that can be used to unsubscribe from the messages.</returns>
        IDisposable Subscribe<T>(Action<T> handler);

        #endregion
    }


    /// <summary>
    ///     Implementation of the IEventBus interface using VContainer and MessagePipe.
    /// </summary>
    public class EventBus : IEventBus
    {
        #region Fields

        /// <summary>
        ///     The object resolver used to resolve dependencies.
        /// </summary>
        private readonly IObjectResolver _resolver;

        #endregion

        #region Constructors and Injected

        /// <summary>
        ///     Initializes a new instance of the EventBus class.
        /// </summary>
        /// <param name="resolver">The object resolver used to resolve dependencies.</param>
        public EventBus(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        #endregion

        #region IEventBus Members

        /// <summary>
        ///     Publishes a message to all subscribers of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the message to publish.</typeparam>
        /// <param name="message">The message to publish.</param>
        public void Publish<T>(T message)
        {
            var publisher = _resolver.Resolve<IPublisher<T>>();
            publisher.Publish(message);
        }


        /// <summary>
        ///     Subscribes to messages of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the message to subscribe to.</typeparam>
        /// <param name="handler">The action to execute when a message is received.</param>
        /// <returns>An IDisposable that can be used to unsubscribe from the messages.</returns>
        public IDisposable Subscribe<T>(Action<T> handler)
        {
            var subscriber = _resolver.Resolve<ISubscriber<T>>();
            return subscriber.Subscribe(handler);
        }

        #endregion
    }


    /// <summary>
    ///     Provides a filter for handling and logging the processing of events in the message pipeline.
    ///     Logs the start and end of event handling for messages of the specified type.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the message being handled by this filter.
    /// </typeparam>
    public class LoggingFilter<T> : MessageHandlerFilter<T>
    {
        #region Methods

        /// <summary>
        ///     Processes a message by applying the current filter logic and passing it to the next handler.
        /// </summary>
        /// <param name="message">The message that is being processed.</param>
        /// <param name="next">The next action in the processing pipeline, which is invoked after the filter logic is applied.</param>
        public override void Handle(T message, Action<T> next)
        {
            DebugEx.Log($"BEGIN: Event {typeof(T).Name}", EventTag.Publish);
            next(message);
            DebugEx.Log($"END: Event {typeof(T).Name}", EventTag.Publish);
        }

        #endregion
    }
}
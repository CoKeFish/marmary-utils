using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Marmary.Utils.Runtime.Extention.UniTask
{
    /// <summary>
    ///     Provides helper methods for working with UniTask, including methods to await multiple tasks
    ///     and capture their results or exceptions.
    /// </summary>
    public class UniTaskHelpers
    {
        #region Methods

        /// <summary>
        ///     Awaits two UniTasks and returns a tuple containing the results or exceptions for each task.
        ///     Ensures that both tasks complete before returning, even if one or both fail.
        /// </summary>
        /// <typeparam name="T1">The result type of the first task.</typeparam>
        /// <typeparam name="T2">The result type of the second task.</typeparam>
        /// <param name="task1">The first task to await.</param>
        /// <param name="task2">The second task to await.</param>
        /// <returns>A tuple containing the results or exceptions of both tasks.</returns>
        public static async UniTask<(Result<T1> Task1Result, Result<T2> Task2Result)> WhenAllSettled<T1, T2>(
            UniTask<T1> task1,
            UniTask<T2> task2)
        {
            var task1Result = await WrapTaskResult(task1);
            var task2Result = await WrapTaskResult(task2);

            return (task1Result, task2Result);
        }

        /// <summary>
        /// Awaits the completion of multiple UniTasks and returns a list of results representing their outcomes.
        /// Each result captures the success or failure of the individual tasks.
        /// </summary>
        /// <param name="tasks">The collection of tasks to await.</param>
        /// <returns>A list of result objects capturing the outcome of each task.</returns>
        public static async UniTask<List<Result>> WhenAllSettled(IEnumerable<Cysharp.Threading.Tasks.UniTask> tasks)
        {
            var resultTasks = tasks.Select(WrapTaskResult).ToList();
            var results = await Cysharp.Threading.Tasks.UniTask.WhenAll(resultTasks);
            return results.ToList();
        }

        /// <summary>
        ///     Awaits a collection of UniTasks and returns a list containing the results or exceptions for each task.
        ///     Ensures that all tasks complete before returning, even if some fail.
        /// </summary>
        /// <typeparam name="T">The result type of each task.</typeparam>
        /// <param name="tasks">The tasks to await.</param>
        /// <returns>A list containing the results or exceptions of all tasks.</returns>
        public static async UniTask<List<Result<T>>> WhenAllSettled<T>(IEnumerable<UniTask<T>> tasks)
        {
            var taskList = tasks.ToList();
            var resultTasks = taskList.Select(WrapTaskResult).ToList();
            var results = await Cysharp.Threading.Tasks.UniTask.WhenAll(resultTasks);
            return results.ToList();
        }


        /// <summary>
        /// Wraps the result of a UniTask, capturing either its value or any exception that occurs during execution.
        /// </summary>
        /// <typeparam name="T">The result type of the UniTask.</typeparam>
        /// <param name="task">The UniTask to be executed and wrapped.</param>
        /// <returns>A Result object containing the value of the task if it succeeds, or the exception if it fails.</returns>
        private static async UniTask<Result<T>> WrapTaskResult<T>(UniTask<T> task)
        {
            try
            {
                var result = await task;
                return new Result<T>(result, null);
            }
            catch (Exception ex)
            {
                return new Result<T>(default, ex);
            }
        }

        /// <summary>
        /// Wraps a UniTask execution into a result object that captures success or exception.
        /// This method ensures that the task completes, and it encapsulates the outcome
        /// (either a successfully completed state or an exception) in a result structure.
        /// </summary>
        /// <param name="task">The UniTask to be executed and wrapped.</param>
        /// <returns>A result object containing either the successful completion state or the caught exception.</returns>
        private static async UniTask<Result> WrapTaskResult(Cysharp.Threading.Tasks.UniTask task)
        {
            try
            {
                await task;
                return new Result(null);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }

        #endregion

        #region Nested type: Result

        /// <summary>
        /// Represents the outcome of a task, including the exception if the task failed.
        /// Used to capture success or failure states after awaiting tasks.
        /// </summary>
        public readonly struct Result
        {
            /// <summary>
            /// Represents the exception that occurred during the execution of a task.
            /// Provides details about the error state when a task fails to complete successfully.
            /// </summary>
            private Exception Exception { get; }

            /// <summary>
            /// Indicates whether the task completed successfully without exceptions.
            /// Returns true if no exception was raised; otherwise, false.
            /// </summary>
            public bool IsSuccess => Exception == null;

            public Result(Exception exception)
            {
                Exception = exception;
            }
        }

        /// <summary>
        /// Represents the result of an operation, encapsulating either a successful value or an exception.
        /// </summary>
        public struct Result<T>
        {
            /// <summary>
            /// Gets the result of the operation if it completed successfully.
            /// If the operation failed, this property will return the default value for the specified type.
            /// </summary>
            public T Value { get; }

            /// <summary>
            /// Represents the error encountered during the execution of a task.
            /// Encapsulates details about the failure state when a task does not succeed.
            /// </summary>
            private Exception Exception { get; }

            /// <summary>
            /// Indicates whether the operation represented by the result was successful.
            /// Returns true if the operation completed without exceptions; otherwise, false.
            /// </summary>
            public bool IsSuccess => Exception == null;

            /// <summary>
            /// Represents the result of a UniTask operation, including its value or an exception if the task failed.
            /// </summary>
            /// <remarks>
            /// This struct is used to encapsulate the outcome of a UniTask. It provides information on whether the task
            /// completed successfully, the value returned (if successful), and the exception encountered (if failed).
            /// </remarks>
            public Result(T value, Exception exception)
            {
                Value = value;
                Exception = exception;
            }
        }

        #endregion
    }
}
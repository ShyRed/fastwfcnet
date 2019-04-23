namespace FastWfcDemoApp.Model
{
    /// <summary>
    /// Logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a neutral message.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        void LogNeutral(string msg);

        /// <summary>
        /// Logs a success message.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        void LogSuccess(string msg);

        /// <summary>
        /// Logs a failure message.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        void LogFailure(string msg);
    }
}

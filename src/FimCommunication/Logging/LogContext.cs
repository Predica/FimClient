using System;
using System.Configuration;
using System.Diagnostics;

namespace Predica.FimCommunication
{
    /// <summary>
    /// Provides additional information about logged operations,
    /// like adding a guid to a group of logs, making them easier to correlate in logs
    /// or adding time that passed since context was instantiated 
    /// </summary>
    public class LogContext
    {
        public static LogContext WithConfigFormat()
        {
            string format = ConfigurationManager.AppSettings["logging.contextformat"];

            return new LogContext(format ?? DEFAULT_FORMAT);
        }

        private readonly string _format;
        private const string DEFAULT_FORMAT = "{elapsed}|{message}|{token}";
        
        private readonly string _token;
        public string Token { get { return _token; } }

        private readonly Stopwatch _stopwatch;

        public LogContext() : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes <see cref="LogContext"/> instance with formatting string that will be used to compose formatted messages.
        /// </summary>
        /// <param name="format">Supported plaholders: {message}, {elapsed}, {token}</param>
        public LogContext(string format)
        {
            _format = format;
            _token = Guid.NewGuid().ToString();
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public string Tokenize(string input)
        {
            if (input.IsNullOrEmpty())
            {
                return "[{0}]".FormatWith(_token);
            }

            return "{0} | [{1}]".FormatWith(input, _token);
        }

        public string TokenizeTime(string input)
        {
            return "[{0}] | {1}".FormatWith(_stopwatch.Elapsed.Format(), Tokenize(input));
        }

        public string Format(string input)
        {
            string output =
                _format.Replace("{elapsed}", _stopwatch.Elapsed.Format())
                    .Replace("{message}", input)
                    .Replace("{token}", _token)
                ;

            return output;
        }

        public TimeSpan Elapsed
        {
            get { return _stopwatch.Elapsed; }
        }
    }
}
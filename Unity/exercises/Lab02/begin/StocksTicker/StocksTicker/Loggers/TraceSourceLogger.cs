//===============================================================================
// Microsoft patterns & practices
// Enterprise Library 6 and Unity 3 Hands-on Labs
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System.Diagnostics;
using Microsoft.Practices.Unity;

namespace StocksTicker.Loggers
{
    public class TraceSourceLogger : ILogger
    {
        private TraceSource traceSource;

        public TraceSourceLogger(string traceSourceName)
            : this(new TraceSource(traceSourceName, SourceLevels.All))
        {
        }

        [InjectionConstructor]
        public TraceSourceLogger(TraceSource traceSource)
        {
            this.traceSource = traceSource;
        }

        public void Log(string message, TraceEventType eventType)
        {
            this.traceSource.TraceEvent(eventType, 0, message);
            this.traceSource.Flush();
        }
    }
}

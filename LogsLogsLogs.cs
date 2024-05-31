using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        switch (Regex.Match(logLine, @"(?<=\[)...(?=\])").Value)
        {
            case "TRC":
                return LogLevel.Trace;
            case "DBG": 
                return LogLevel.Debug;
            case "INF":
                return LogLevel.Info;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        switch (logLevel)
        {
            case LogLevel.Trace:
                return $"{(int)LogLevel.Trace}:{message}";
            case LogLevel.Debug:
                return $"{(int)LogLevel.Debug}:{message}";
            case LogLevel.Info:
                return $"{(int)LogLevel.Info}:{message}";
            case LogLevel.Warning:
                return $"{(int)LogLevel.Warning}:{message}";
            case LogLevel.Error:
                return $"{(int)LogLevel.Error}:{message}";
            case LogLevel.Fatal:
                return $"{(int)LogLevel.Fatal}:{message}";
            case LogLevel.Unknown:
            default:
                return $"{(int)LogLevel.Unknown}:{message}";
        }
    }        
}

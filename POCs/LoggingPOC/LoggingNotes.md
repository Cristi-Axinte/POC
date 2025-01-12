# This document contains important notes about Logging

## General Logging Knoledge

### Why is logging good 
    Logging provides a way to monitor the application's behavior and track events for troubleshooting, debugging, and analytics.
    
### Log Levels:

    LogLevel indicates the severity of the log and ranges from 0 to 6:

**Trace** = 0 - Logs that contain the most detailed messages. These messages may contain sensitive application data. These messages are disabled by default and should never be enabled in a production environment. ( we have to use .Verbose in the serilog configuration in our case )

**Debug** = 1 - Logs that are used for interactive investigation during development. These logs should primarily contain information useful for debugging and have no long-term value.
    
**Information** = 2 - Logs that track the general flow of the application. These logs should have long-term value.

**Warning** = 3 - Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the application execution to stop.
    
**Error** = 4 - Logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a failure in the current activity, not an application-wide failure.

**Critical** = 5 - Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires immediate attention.

**None** = 6 - Not used for writing log messages. Specifies that a logging category should not write any messages.

# Serilog Overview
    Serilog is a popular, flexible logging framework for .NET, which allows developers to capture logs in structured formats (JSON, text, etc.) and sends them to various sinks (destinations like console, file, HTTP, databases, etc.).

## Setting Up Serilog:
    Serilog is configured during the application startup in the Program.cs file. The configuration includes specifying sinks ( where logs are stored ), log levels, and formatting options.

    The current implementation writes logs in console, in a file and to an in memory database, by doing an http request to LogsReceiver ( project created just to store logs )\

    To the LogsReceiver project we are sending all the details about the log, and we are storing its id, level, message and timestamp



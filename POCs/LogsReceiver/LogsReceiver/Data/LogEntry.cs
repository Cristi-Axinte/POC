﻿namespace LogsReceiver.Data
{
    public class LogEntry
    {
        public int Id { get; set; } 
        public string Message { get; set; }
        public string Level { get; set; }
        public string Timestamp { get; set; }
    }
}
﻿namespace Clean_Code.Models.Response
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

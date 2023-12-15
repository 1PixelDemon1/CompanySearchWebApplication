﻿namespace EventManagerService.API.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object? Data { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

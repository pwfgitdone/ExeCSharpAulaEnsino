﻿namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.Responses
{
    public class ResponseFalha
    {
        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}

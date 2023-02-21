using System;

namespace educationprogramAPI.Models.Responses
{
    public class BaseResponse<T> : IResponse
    {
        public BaseResponse() { }

        public T Data { get; set; }
        private bool _isSuccess;
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = Exception is null; }
        }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public string Status {get; set; } 
    }
}

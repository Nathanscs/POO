namespace Poo.Api.Controllers.Contracts;

    public class ResponseDto
    {
        public ResponseDto(object data)
        {
            Data = data;
        }

        public ResponseDto(Exception exception)
        {
            Error = new ErrorDto(exception);
        }
        
        public object Data { get; }

        public ErrorDto Error { get; }

        public class ErrorDto
        {
            public ErrorDto(Exception exception)
            {
                Message = exception.Message;
                Data = exception.Data;
            }
            
            public string Message { get; }
            public object Data { get; }
        }
    }

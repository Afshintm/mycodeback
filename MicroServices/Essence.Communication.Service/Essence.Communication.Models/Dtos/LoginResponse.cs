namespace Essence.Communication.Models.Dtos
{
    public class LoginResponse:ResponseBase
    {
        public LoginResponse()
        {

        }

        public LoginResponse(ResponseBase response): base(response)
        {

        }
        public string token { get; set; } 
    }
}

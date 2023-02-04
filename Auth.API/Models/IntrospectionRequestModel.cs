namespace Auth.API.Models
{
    public class IntrospectionRequestModel
    {
        public string Token { get; set; }

        public IntrospectionRequestModel(string token)
        {
            Token = token;
        }
    }
}

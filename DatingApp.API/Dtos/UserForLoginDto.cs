namespace DatingApp.API.Dtos
{
    public class UserForLoginDto
    {
        // not adding validation, it will be done by the APi
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
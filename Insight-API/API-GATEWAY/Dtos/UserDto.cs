namespace WebApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email{get; set;}
        public string Password { get; set; }
        public string TokenString { get ; set ;}
        public string secret{get; set;}
         public string secretregister{get; set;}
         public string photoUrl{get; set;}

      

    }
}
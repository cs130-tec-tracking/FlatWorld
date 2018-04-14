namespace Stage.App.Models
{

    public class Signup
    {
        public SignupName name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class SignupName
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

}
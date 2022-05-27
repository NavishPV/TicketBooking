namespace TicketBooking.Models
{
    public class CustomerModels
    {

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public  string Mobile { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Password { get; set; }





        public CustomerModels()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Email = "";
            Mobile = "";
            City = "";
            State = "";
            Password = "";

        }
        public bool IsValid()
        {
            if (FirstName == null || FirstName.Trim() == "" || FirstName.Trim().Length > 30)
            {
                return false;
            }


            if (LastName == null || LastName.Trim() == "" || LastName.Trim().Length > 30)
            {
                return false;
            }

            if (Email == null || Email.Trim() == "" || Email.Trim().Length > 30)
            {
                return false;
            }
            if (Mobile == null || Mobile.Trim() == "" || Mobile.Trim().Length > 20)
            {
                return false;
            }

            if (City == null || Mobile.Trim() == "" || Mobile.Trim().Length > 20)
            {
                return false;
            }

            if (State == null || State.Trim() == "" || State.Trim().Length > 20)
            {
                return false;
            }
            return true;


            if (Password == null || Password.Trim() == "" || Password.Trim().Length > 20)
            {
                return false;
            }
            return true;
        }





    }
}

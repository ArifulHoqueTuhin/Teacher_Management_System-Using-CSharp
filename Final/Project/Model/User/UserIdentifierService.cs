namespace Project.Model.UserIdentity
{
    public class UserIdentifierService
    {
        private readonly IUserIdentifier _userIdentifier;
        public UserIdentifierService(IUserIdentifier userIdentifier)
        {
            _userIdentifier = userIdentifier;
        }

        public bool UserService(string usertype)
        {
            var type = _userIdentifier.User(usertype);
            var res = type.Operation();
            if (res)
            {
                Console.WriteLine("Operation is successfull");
                return true;
            }
            else
            {
                return false;
            }
                
        }
    }
}

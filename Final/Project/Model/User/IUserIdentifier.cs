namespace Project.Model.UserIdentity
{
    public interface IUserIdentifier
    {
        IUserOperation User(string usertype);
    }
}

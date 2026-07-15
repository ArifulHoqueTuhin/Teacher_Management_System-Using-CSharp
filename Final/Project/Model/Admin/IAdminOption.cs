using System;


namespace Project.Model.Admin
{
    public interface IAdminOption
    {
        IAdminOperationType OperationType(string option);
    }
}

using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    public interface IDataProvider
    {
        //List<UserType> GetUserType();
        //List<UserType> InsertUserType(int UserTypeID, string Description);
        //List<UserType> DeleteUserType(int UserTypeID);
        //List<UserType> UpdateUserType(int UserTypeID, string Description);
        List<UserInformation> GetUserInformation();
        List<UserInformation> InsertUserInformation(int UserTypeID, string UserName, string Password, string Email, string GivenName, string MaidenName, string FamilyName);
        List<UserInformation> DeleteUserInformation(int UserInformationID);
        List<UserInformation> UpdateUserInformation(int UserInformationID, string GivenName, string Password, string MaidenName, string FamilyName);
        List<UserInformation> LoginUserInformation(string UserName, string Password); 
    }
}

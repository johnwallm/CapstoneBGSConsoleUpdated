using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    using Dapper;
    using System.Data;
    using System.Data.SqlClient;
    using System.Security.Cryptography.X509Certificates;

    public class DataProvider : DataAccess, IDataProvider
    {
        //#region View
        //public List<UserType> GetUserType()
        //{
        //    var result = new List<UserType>();
        //    using (IDbConnection con = new SqlConnection(constring))
        //    {
        //        con.Open();
        //        result = con.Query<UserType>(
        //            StoredProcedureEnum.V_UserType.ToString(), commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    return result;
        //}
        //#endregion

        //#region Insert
        //public List<UserType> InsertUserType(int UserTypeID, string Description)
        //{
        //    var result = new List<UserType>();
        //    using (IDbConnection con = new SqlConnection(constring))
        //    {
        //        con.Open();
        //        var param = new DynamicParameters();
        //        param.Add("@UserTypeID", UserTypeID);
        //        param.Add("@Description", Description);

        //        result = con.Query<UserType>(
        //            StoredProcedureEnum.I_UserType.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    return result;
        //}
        //#endregion


        //#region Delete
        //public List<UserType> DeleteUserType(int UserTypeID)
        //{
        //    var result = new List<UserType>();
        //    using (IDbConnection con = new SqlConnection(constring))
        //    {
        //        con.Open();
        //        var param = new DynamicParameters();
        //        param.Add("@UserTypeID", UserTypeID);

        //        result = con.Query<UserType>(
        //            StoredProcedureEnum.D_UserType.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    return result;
        //}
        //#endregion

        //#region Update
        //public List<UserType> UpdateUserType(int UserTypeID, string Description)
        //{
        //    var result = new List<UserType>();
        //    using (IDbConnection con = new SqlConnection(constring))
        //    {
        //        con.Open();
        //        var param = new DynamicParameters();
        //        param.Add("@UserTypeID", UserTypeID);
        //        param.Add("@Description", Description);

        //        result = con.Query<UserType>(
        //            StoredProcedureEnum.U_UserType.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    return result;
        //}
        //#endregion

        public List<UserInformation> GetUserInformation() //UserInformationView
        {
            var result = new List<UserInformation>();
            using (IDbConnection con = new SqlConnection(constring))
            {
                con.Open();
                result = con.Query<UserInformation>(
                    StoredProcedureEnum.V_UserInformation.ToString(), commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }


        public List<UserInformation> InsertUserInformation(int UserTypeID, string UserName, string Password, string Email, string GivenName, string MaidenName, string FamilyName)
        ///Insert User information
        {
            var result = new List<UserInformation>();
            using (IDbConnection con = new SqlConnection(constring))
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@UserTypeID", UserTypeID);
                param.Add("@UserName", UserName);
                param.Add("@Password", Hash.HashPassword(Password));
                param.Add("@Email", Email);
                param.Add("@GivenName", GivenName);
                param.Add("@MaidenName", MaidenName);
                param.Add("@FamilyName", FamilyName);

                result = con.Query<UserInformation>(
                        StoredProcedureEnum.I_UserInformation.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;

        }

        public List<UserInformation> DeleteUserInformation(int UserInformationID) //delete user information
        {
            var result = new List<UserInformation>();
            using (IDbConnection con = new SqlConnection(constring))
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@UserInformationID", UserInformationID);

                result = con.Query<UserInformation>(
                    StoredProcedureEnum.D_UserInformation.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public List<UserInformation> UpdateUserInformation(int UserInformationID, string GivenName, string MaidenName, string FamilyName, string Password) ////update user information
        {
            var result = new List<UserInformation>();
            using (IDbConnection con = new SqlConnection(constring))
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@UserInformationID", UserInformationID);
                param.Add("@GivenName", GivenName);
                param.Add("@Password", Password);
                param.Add("@MaidenName", MaidenName);
                param.Add("FamilyName", FamilyName);


                result = con.Query<UserInformation>(
                    StoredProcedureEnum.U_UserInformation.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public List<UserInformation> LoginUserInformation(string UserName, string Password)
        {
            var result = new List<UserInformation>();
            using (IDbConnection con = new SqlConnection(constring))
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@UserName", UserName);
                param.Add("@Password", Password);

                result = con.Query<UserInformation>(
                    StoredProcedureEnum.L_UserInformation.ToString(), param, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;

        }







    }
}
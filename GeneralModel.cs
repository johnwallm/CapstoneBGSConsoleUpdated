using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    //public class UserType
    //{
     
    //    public int UserTypeID
    //    { get; set; }

    //    public string Description
    //    { get; set; }


    //    public string Notes
        
    //       { get; set; }
        
    //}

    public class UserInformation
    {
       
        public int UserInformationID
        { get; set; }

        
        public int UserTypeID
        { get; set; }


       
        public string UserName
        { get; set; }

        
        public string Password
        { get; set; }

       
        public string GivenName
        { get; set; }

        
        public string MaidenName
        { get; set; }

        
        public string FamilyName
        { get; set; }

        
        public string Email
        { get; set; }

       
        public string CaseReportPhoto
        { get; set; }

       
        public string CaseLocation
        { get; set; }

    }

}

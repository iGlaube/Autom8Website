using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAspNetUserService" in both code and config file together.
    [ServiceContract]
    public interface IAspNetUserService
    {
        [OperationContract]
        void createUser(byte[] profilePicture, string firstName, string lastName, string title, string yearOfBirth, string homeNumber, string mobileNumber, string addressLine1,
            string addressLine2, string cityTown, string postcode, string biography, string email, bool emailConfirmed, string passwordHash, string securityStamp, string phoneNumber, bool phoneNumberConfirmed,
            bool twoFactorEnabled, DateTime lockoutEndDate, bool lockoutEnabled, int accessFailedCount, string userName);

        [OperationContract]
        ApplicationUser retrieveUser(string userID);

        [OperationContract]
        List<ApplicationUser> retrieveAllUsers();

        [OperationContract]
        void updateUser(string userID, byte[] profilePicture, string firstName, string lastName, string title, string yearOfBirth, string homeNumber, string mobileNumber, string addressLine1,
            string addressLine2, string cityTown, string postcode, string biography, string email, bool emailConfirmed, string passwordHash, string securityStamp, string phoneNumber, bool phoneNumberConfirmed,
            bool twoFactorEnabled, DateTime lockoutEndDate, bool lockoutEnabled, int accessFailedCount, string userName);

        [OperationContract]
        void updateUserBasicInfo(string userID, string firstName, string lastName, string title, string yearOfBirth, string homeNumber, string mobileNumber, string addressLine1, string addressLine2,
        string cityTown, string postcode, string biography, string email);

        [OperationContract]
        void deleteUser(string userID);
    }
}

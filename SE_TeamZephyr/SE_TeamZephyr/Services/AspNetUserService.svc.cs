using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AspNetUserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AspNetUserService.svc or AspNetUserService.svc.cs at the Solution Explorer and start debugging.
    public class AspNetUserService : IAspNetUserService
    {
        public void createUser(byte[] profilePicture, string firstName, string lastName, string title, string yearOfBirth, string homeNumber, string mobileNumber, string addressLine1,
            string addressLine2, string cityTown, string postcode, string biography, string email, bool emailConfirmed, string passwordHash, string securityStamp, string phoneNumber, bool phoneNumberConfirmed,
            bool twoFactorEnabled, DateTime lockoutEndDate, bool lockoutEnabled, int accessFailedCount, string userName)
        {
            using (IdentityDBContext DBContext = new IdentityDBContext())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    ProfilePicture = profilePicture,
                    FirstName = firstName,
                    LastName = lastName,
                    Title = title,
                    YearOfBirth = yearOfBirth,
                    HomeNumber = homeNumber,
                    MobileNumber = mobileNumber,
                    AddressLine1 = addressLine1,
                    AddressLine2 = addressLine2,
                    CityTown = cityTown,
                    PostCode = postcode,
                    Biography = biography,
                    Email = email,
                    EmailConfirmed = emailConfirmed,
                    PasswordHash = passwordHash,
                    SecurityStamp = securityStamp,
                    PhoneNumber = phoneNumber,
                    PhoneNumberConfirmed = phoneNumberConfirmed,
                    TwoFactorEnabled = twoFactorEnabled,
                    LockoutEndDateUtc = lockoutEndDate,
                    LockoutEnabled = lockoutEnabled,
                    AccessFailedCount = accessFailedCount,
                    UserName = userName
                };
                DBContext.Users.Add(user);
                DBContext.SaveChanges();
            }
        }

        public ApplicationUser retrieveUser(string userID)
        {
            using (IdentityDBContext DBContext = new IdentityDBContext())
            {
                var user = DBContext.Users.Where(a => a.Id == userID).FirstOrDefault();
                if (user == new ApplicationUser())
                {
                    throw new Exception();
                }
                return user;
            }
        }

        public List<ApplicationUser> retrieveAllUsers()
        {
            using (IdentityDBContext DBContext = new IdentityDBContext())
            {
                var users = DBContext.Users.ToList();
                if (users.Count > 0)
                {
                    return users;
                }
                return new List<ApplicationUser>();
            }
        }

        public void updateUserBasicInfo(string userID, string firstName, string lastName, string title, string yearOfBirth, string homeNumber, string mobileNumber, string addressLine1, string addressLine2,
            string cityTown, string postcode, string biography, string email)
        {
            using (IdentityDBContext DBContext = new IdentityDBContext())
            {
                var existingAspNetUser = DBContext.Users.Single(u => u.Id == userID);
                existingAspNetUser.FirstName = firstName;
                existingAspNetUser.LastName = lastName;
                existingAspNetUser.Title = title;
                existingAspNetUser.YearOfBirth = yearOfBirth;
                existingAspNetUser.HomeNumber = homeNumber;
                existingAspNetUser.MobileNumber = mobileNumber;
                existingAspNetUser.AddressLine1 = addressLine1;
                existingAspNetUser.AddressLine2 = addressLine2;
                existingAspNetUser.CityTown = cityTown;
                existingAspNetUser.PostCode = postcode;
                existingAspNetUser.Biography = biography;
                existingAspNetUser.Email = email;
                DBContext.SaveChanges();
            }
        }

        public void updateUser(string userID, byte[] profilePicture, string firstName, string lastName, string title, string yearOfBirth, string homeNumber, string mobileNumber, string addressLine1,
            string addressLine2, string cityTown, string postcode, string biography, string email, bool emailConfirmed, string passwordHash, string securityStamp, string phoneNumber, bool phoneNumberConfirmed,
            bool twoFactorEnabled, DateTime lockoutEndDate, bool lockoutEnabled, int accessFailedCount, string userName)
        {
            using (IdentityDBContext DBContext = new IdentityDBContext())
            {
                var existingAspNetUser = DBContext.Users.Single(u => u.Id == userID);
                existingAspNetUser.Id = userID;
                existingAspNetUser.ProfilePicture = profilePicture;
                existingAspNetUser.FirstName = firstName;
                existingAspNetUser.LastName = lastName;
                existingAspNetUser.Title = title;
                existingAspNetUser.YearOfBirth = yearOfBirth;
                existingAspNetUser.HomeNumber = homeNumber;
                existingAspNetUser.MobileNumber = mobileNumber;
                existingAspNetUser.AddressLine1 = addressLine1;
                existingAspNetUser.AddressLine2 = addressLine2;
                existingAspNetUser.CityTown = cityTown;
                existingAspNetUser.PostCode = postcode;
                existingAspNetUser.Biography = biography;
                existingAspNetUser.Email = email;
                existingAspNetUser.EmailConfirmed = emailConfirmed;
                existingAspNetUser.PasswordHash = passwordHash;
                existingAspNetUser.SecurityStamp = securityStamp;
                existingAspNetUser.PhoneNumber = phoneNumber;
                existingAspNetUser.PhoneNumberConfirmed = phoneNumberConfirmed;
                existingAspNetUser.TwoFactorEnabled = twoFactorEnabled;
                existingAspNetUser.LockoutEndDateUtc = lockoutEndDate;
                existingAspNetUser.LockoutEnabled = lockoutEnabled;
                existingAspNetUser.AccessFailedCount = accessFailedCount;
                existingAspNetUser.UserName = userName;
                DBContext.SaveChanges();
            }
        }

        public void deleteUser(string userID)
        {
            using (IdentityDBContext DBContext = new IdentityDBContext())
            {
                DBContext.Users.Remove(DBContext.Users.Where(a => a.Id == userID).First());
                DBContext.SaveChanges();
            }
        }
    }
}

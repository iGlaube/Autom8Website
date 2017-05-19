using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContactFormService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ContactFormService.svc or ContactFormService.svc.cs at the Solution Explorer and start debugging.
    public class ContactFormService : IContactFormService
    {
        public void createContactForm(string userName, string userEmail, string contactSubject, string contactComments, string contactStatus)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                ContactForm contactForm = new ContactForm()
                {
                    UserName = userName,
                    UserEmail = userEmail,
                    ContactSubject = contactSubject,
                    ContactComments = contactComments,
                    ContactStatus = contactStatus
                };
                DBContext.ContactForms.Add(contactForm);
                DBContext.SaveChanges();
            }
        }

        public ContactForm retrieveContactForm(int contactFormID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var contactForm = DBContext.ContactForms.Where(a => a.ContactFormID == contactFormID).FirstOrDefault();
                if (contactForm == new ContactForm())
                {
                    throw new Exception();
                }
                return contactForm;
            }
        }

        public List<ContactForm> retrieveAllContactForms()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var contactForms = DBContext.ContactForms.ToList();
                if (contactForms.Count > 0)
                {
                    return contactForms;
                }
                return new List<ContactForm>();
            }
        }

        public void updateContactForm(int contactFormID, string userName, string userEmail, string contactSubject, string contactComments, string contactStatus)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingContactForm = DBContext.ContactForms.Single(c => c.ContactFormID == contactFormID);
                existingContactForm.ContactFormID = contactFormID;
                existingContactForm.UserName = userName;
                existingContactForm.UserEmail = userEmail;
                existingContactForm.ContactSubject = contactSubject;
                existingContactForm.ContactComments = contactComments;
                existingContactForm.ContactStatus = contactStatus;
                DBContext.SaveChanges();
            }
        }

        public void deleteContactForm(int contactFormID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.ContactForms.Remove(DBContext.ContactForms.Where(a => a.ContactFormID == contactFormID).First());
                DBContext.SaveChanges();
            }
        }
    }
}

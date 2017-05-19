using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContactFormService" in both code and config file together.
    [ServiceContract]
    public interface IContactFormService
    {
        [OperationContract]
        void createContactForm(string userName, string userEmail, string contactSubject, string contactComments, string contactStatus);
        [OperationContract]
        ContactForm retrieveContactForm(int contactFormID);
        [OperationContract]
        List<ContactForm> retrieveAllContactForms();
        [OperationContract]
        void updateContactForm(int contactFormID, string userName, string userEmail, string contactSubject, string contactComments, string contactStatus);
        [OperationContract]
        void deleteContactForm(int contactFormID);
    }
}

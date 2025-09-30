using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// A directory composes persons
    /// </summary>
    /// <see cref="Person"/>
    [DataContract]
    public class Directory
    {
        #region associations
        [DataMember]
        private List<IPerson> contacts;
        #endregion

        #region operations
        /// <summary>
        /// Add a person as a contact
        /// </summary>
        /// <param name="p">the person to add</param>
        public void NewContact(IPerson p)
        {
                       
            this.contacts.Add(p);
            
        }
        /// <summary>
        /// Remove a person from the contacts
        /// </summary>
        /// <param name="p">person to remove</param>
        public void RemoveContact(IPerson p)
        {
          
             contacts.Remove(p);
              
        }
        /// <summary>
        /// List all the contacts
        /// </summary>
        /// <returns>An simple array containing contacts</returns>
        public IPerson[]? ListContacts()
        {
            return contacts?.ToArray();
        }

        /// <summary>
        /// Get persons with lastname starts with the give letter 
        /// </summary>
        /// <param name="initial">the initial (case-sensitive)</param>
        /// <returns>an array with the contacts found</returns>
        public IPerson[] ListContacts(char initial)
        {
            List<IPerson> res = new List<IPerson> ();
            foreach (IPerson p in contacts)
            {
                if (p.LastName[0] == initial)
                {
                    res.Add(p);
                }
            }
            return res.ToArray();
        }
        #endregion

        #region builder
        public Directory()
        {
            contacts = new List<IPerson>();
        }
        #endregion
    }
}

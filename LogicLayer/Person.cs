using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogicLayer
{
	    /// <summary>
    /// Exception thrown when we try to set an empty name
    /// </summary>
    public class NameEmptyException:Exception
    {

    }

    [DataContract]
    public class Person : IPerson, ICloneable
    {
        #region attributes
        [DataMember]
        private string? firstName;
        [DataMember]
        private string lastName;
        [DataMember]
        private string? address;
        [DataMember]
        private string? phoneNumber;
        [DataMember]
        private GenderType gender;
        #endregion

        #region properties	
        public string LastName 
		{ 
			get 
            {
                return lastName;
            } 
			set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new NameEmptyException();
                lastName = value;
            } 
		}
        public string? FirstName 
		{ 
			get
            {
                return firstName; 
            }
            set
            {
                firstName = value ;
            }
        }
        
        public string? Address 
		{
            get
            {
                return address;
            }
			set 
            {
                address = value;
            } 
		}

        public string? PhoneNumber 
		{ 
			get 
            {
                return phoneNumber;
            }
			set 
            {   
                phoneNumber = value;
            }
		}

        public string Identity
        {
            get 
            {
                return LastName.ToUpper() + " " + FirstName[0].ToString().ToUpper() +  FirstName.Substring(1).ToLower(); ;

            }
        }

        public  GenderType Gender
        {
            get
            {  
                return gender; 
            }
            set 
            {
                gender = value;
            }
                
        }
        #endregion

        #region builder 

        /// <summary>
        /// Init a person
        /// </summary>
        /// <param name="last">person's lastname (must not be empty)</param>
        /// <param name="first">person's firstname</param>
        /// <exception cref="NameEmptyException">if an empty lastname is set</exception>
        public Person(string last, string first, GenderType gender = GenderType.NEUTRAL)
        {
            this.lastName = last;
            this.firstName = first;
            this.address = null;
            this.phoneNumber = null;
            this.gender = gender;
        }

        /// <summary>
        /// Init a 2nd person identical to the one given
        /// </summary>
        /// <param name="person">the person to copy</param>
        public Person(Person person)
        {
            this.Copy(person);
        }
        #endregion

        #region Methods

        /// <summary>
        /// get a string value of the person
        /// </summary>
        /// <returns>a string contains the person's last & first names</returns>
        public override string ToString()
        {
            return Identity;
        }

        /// <summary>
        /// Create a new person based on another Person
        /// </summary>
        /// <param name="person"></param>
        public void Copy(IPerson person)
        {
            this.firstName = person.FirstName;
            this.lastName = person.LastName;
            this.address = person.Address;
            this.phoneNumber = person.PhoneNumber;
            this.gender = person.Gender;
        }

        /// <summary>
        /// Test if all the attributes of the persons are equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   this.firstName == person.firstName &&
                   this.lastName == person.lastName &&
                   this.address == person.address &&
                   this.phoneNumber == person.phoneNumber &&
                   this.gender == person.gender;
        }
        #endregion

        public object Clone()
        {
            return new Person(this);
        }

    }
}

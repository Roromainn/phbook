namespace LogicLayer
{
    public interface IPerson : ICloneable
    {

        /// <summary>
        /// get or set the person's address
        /// </summary>
        string? Address { get; set; }

        /// <summary>
        /// get or set the person first name.
        /// </summary>
        string? FirstName { get; set; }

        /// <summary>
        /// get the person's gender
        /// </summary>
        GenderType Gender { get; set; }

        /// <summary>
        /// get the person's identity (LastName FirstName)
        /// </summary>
        string Identity { get; }

        /// <summary>
        /// get or set the person last name
        /// </summary>
        /// <exception cref="NameEmptyException">if an empty name is set</exception>	
        string LastName { get; set; }

        /// <summary>
        /// get or set the phone number of the person
        /// </summary>
        string? PhoneNumber { get; set; }

        /// <summary>
        /// Create a new person based on another Person
        /// </summary>
        /// <param name="person"></param>
        void Copy(IPerson person);
    }
}
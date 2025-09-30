using LogicLayer;
using System.Windows.Media.Imaging;

namespace HMI
    {
        public class PersonHMI : IPerson
        {
            #region attributes
            IPerson person;
            #endregion
            #region builder
            public PersonHMI(IPerson person)
            {
                this.person = person;
            }
            #endregion
            #region properties

            public string? Address { get => person.Address; set => person.Address = value; }
            public string? FirstName { get => person.FirstName; set => person.FirstName = value; }
            public GenderType Gender { get => person.Gender; set => person.Gender = value; }

            public string Identity => person.Identity;

            public string LastName { get => person.LastName; set => person.LastName = value; }
            public string? PhoneNumber { get => person.PhoneNumber; set => person.PhoneNumber = value; }

            /// <summary>
            /// deals with the image that has to be shown
            /// </summary>
            public BitmapImage? Icon
            {
                get
                {
                    BitmapImage? res = null;
                    switch (Gender)
                    {
                        case GenderType.FEMALE:
                            res = new BitmapImage(new Uri("pack://application:,,,/Images/contact_f.png"));
                            break;
                        case GenderType.MALE:
                            res = new BitmapImage(new Uri("pack://application:,,,/Images/contact_m.png"));
                            break;
                        default:
                            res = new BitmapImage(new Uri("pack://application:,,,/Images/contact_x.png"));
                            break;
                       
                    }
                    return res;
                }
            }

            /// <summary>
            /// shows the person depicted
            /// </summary>
            public IPerson InnerPerson
            {
                get { return person; }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMale
        {
            get
            {
                return this.Gender == GenderType.MALE;
            }
            set
            {
                if (value)
                {
                    person.Gender = GenderType.MALE;
                }
            }
        }

        public bool IsFemale
        {
            get
            {
                return this.Gender == GenderType.FEMALE;
            }
            set
            {
                if (value)
                {
                    person.Gender = GenderType.FEMALE;
                }
            }
        }
        #endregion

        #region methods
        public object Clone()
            {
            return new PersonHMI((IPerson)person.Clone()); 
            }

            public void Copy(IPerson person)
            {
                this.person.Copy(person);
            }
        }
        #endregion
    }

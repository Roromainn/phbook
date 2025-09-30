using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MockStorage : IStorage
    {
        public IPerson Create()
        {
            return new Person("?", "");

        }

        public void Delete(IPerson p)
        {
            throw new NotImplementedException();
        }

        public Directory Load()
        {
            Directory directory = new Directory();

            directory.NewContact(new Person("harris", "steve", GenderType.MALE));
            directory.NewContact(new Person("dickinson", "bruce", GenderType.MALE));
            directory.NewContact(new Person("murray", "dave", GenderType.MALE));
            directory.NewContact(new Person("smith", "adrian", GenderType.MALE));
            directory.NewContact(new Person("gers", "jannick", GenderType.MALE));
            directory.NewContact(new Person("mc brain", "nicko", GenderType.MALE));

            return directory;
        }

        public void Update(IPerson p)
        {
            throw new NotImplementedException();
        }
    }
}

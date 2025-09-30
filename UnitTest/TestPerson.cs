using LogicLayer;

namespace UnitTests
{
    public class TestPerson
    {
        private Person CreatePerson()
        {
            return new Person("doe", "john");
        }

        [Fact]
        public void TestFirstName()
        {
            Person p = CreatePerson();
            Assert.Equal("john", p.FirstName);
            p.FirstName = "bill";
            Assert.Equal("bill", p.FirstName);
        }

        [Fact]
        public void TestLastName()
        {
            Person p = CreatePerson();
            Assert.Equal("doe", p.LastName);
            p.LastName = "smith";
            Assert.Equal("smith", p.LastName);
        }
		
		[Fact]
        public void TestEmptyLastName()
        {
            Person p = CreatePerson();
            Assert.Throws<NameEmptyException>(() => p.LastName = "");
        }

        [Fact]
        public void TestAddress()
        {
            Person p = CreatePerson();
            String s = "7b, sesame street";
            p.Address = s;
            Assert.Equal(s, p.Address);
        }

        [Fact]
        public void TestPhone()
        {
            Person p = CreatePerson();
            string s = "03-80-81-82-83";
            p.PhoneNumber = s;
            Assert.Equal(s, p.PhoneNumber);
        }

        [Fact]
        public void TestIdentity()
        {
            Person p = CreatePerson();
            Assert.Equal("DOE John", p.Identity);	
        }

        [Fact]
        public void TestCopieConstructeur()
        {
            Person original = new Person("john", "doe");
            original.Address = "rue de la paix"; 
            original.PhoneNumber = "2222";
            Person copy = new Person(original);
            Assert.Equal(original.LastName, copy.LastName);
            Assert.Equal(original.FirstName, copy.FirstName);
            Assert.Equal(original.Address, copy.Address);
            Assert.Equal(original.PhoneNumber, copy.PhoneNumber);
            Assert.Equal(original.Gender, copy.Gender);
            Assert.Equal(original, copy);
        }
        [Fact]
        public void TestCopieMethodes()
        {
            Person original = new Person("john", "does", GenderType.MALE); 
            original.Address = "rue de la guerre";
            original.PhoneNumber = "11111";
            Person copy = new Person("johnny", "doe"); 
            copy.Copy(original);
            Assert.Equal(original.LastName, copy.LastName);
            Assert.Equal(original.FirstName, copy.FirstName);
            Assert.Equal(original.Address, copy.Address);
            Assert.Equal(original.PhoneNumber, copy.PhoneNumber);
            Assert.Equal(original.Gender, copy.Gender);
            Assert.Equal(original, copy);
        }
        [Fact]
        public void TestCopieIndependence()
        {
            Person original = new Person("jean", "chevre",GenderType.FEMALE);
            original.Address = "rue de la neutralite";
            Person copy = new Person(original); 
            copy.FirstName = "frederique"; 
            copy.Address = "ruru";
            Assert.NotEqual(original.FirstName, copy.FirstName); 
            Assert.NotEqual(original.Address, copy.Address); 
            Assert.Equal(original.Gender, copy.Gender);
            Assert.NotEqual(original, copy);
        }
    }
}
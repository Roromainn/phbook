using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class TestDirectory
    {
        
        [Fact]
        public void TestNew()
        {
            LogicLayer.Directory d = new LogicLayer.Directory();
            d.NewContact(new LogicLayer.Person("doe", "john"));
            Assert.Single(d.ListContacts());            
            Assert.Equal("doe", d.ListContacts()[0].LastName);
            d.NewContact(new LogicLayer.Person("toto", ""));
            Assert.Equal(2, d.ListContacts().Length);
            Assert.Equal("toto", d.ListContacts()[1].LastName);
        }

        [Fact]
        public void TestRemove()
        {
            LogicLayer.Directory d = new LogicLayer.Directory();
            LogicLayer.Person p = new LogicLayer.Person("doe", "john");
            d.NewContact(p);
            d.NewContact(new LogicLayer.Person("toto", ""));
            d.RemoveContact(p);
            Assert.Single(d.ListContacts());
            Assert.Equal("toto", d.ListContacts()[0].LastName);
        }

        [Fact]
        public void TestListWithInitial()
        {
            LogicLayer.Directory d = new LogicLayer.Directory();
            d.NewContact(new LogicLayer.Person("doe", "john"));
            d.NewContact(new LogicLayer.Person("toto", ""));
            d.NewContact(new LogicLayer.Person("dandy", "bill"));

            LogicLayer.IPerson[] dPers = d.ListContacts('d');
            Assert.Equal(2, dPers.Length);
            Assert.Equal("dandy", dPers[1].LastName);
        }
        
    }
}

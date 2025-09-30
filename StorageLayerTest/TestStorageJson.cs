using LogicLayer;

namespace TestJsonStorage
{
    public class TestStorageJson
    {
        private string testFile;

        public TestStorageJson()
        {
            testFile = Path.GetTempFileName();
        }

        private void RemoveFile()
        {
            File.Delete(testFile);
        }

        

        [Fact]
        public void TestCreateAndLoad()
        {
            
            // create the storage
            JsonStorage.StorageJson storage = new JsonStorage.StorageJson(testFile);
            LogicLayer.Directory d = storage.Load();

            // first, create a simple directory
            Person p1 = (Person)storage.Create();
            p1.LastName = "toto";
            p1.Gender = GenderType.MALE;
            Person p2 = (Person)storage.Create();
            p2.LastName = "tata";
            p2.Gender = GenderType.FEMALE;
            d.NewContact(p1);
            d.NewContact(p2);
            // and force saving
            storage.Update(p1);
            storage.Update(p2);

            // then reload it !
            LogicLayer.Directory d2 = storage.Load();

            // test if people ok
            var people = d2.ListContacts();
            Assert.Equal(2, people.Length);
            Assert.Equal(p1, people[0]);
            Assert.Equal(p2, people[1]);

            // clean up 
            RemoveFile();
        }

        [Fact]
        public void TestDeleteAndLoad()
        {
            // create the storage
            JsonStorage.StorageJson storage = new JsonStorage.StorageJson(testFile);
            LogicLayer.Directory d = storage.Load();

            // first, create a simple directory
            Person p1 = (Person)storage.Create();
            p1.LastName = "toto";
            p1.Gender = GenderType.MALE;
            Person p2 = (Person)storage.Create();
            p2.LastName = "tata";
            p2.Gender = GenderType.FEMALE;
            d.NewContact(p1);
            d.NewContact(p2);
            // and force saving
            storage.Update(p1);
            storage.Update(p2);
            // then, delete a person
            d.RemoveContact(p1);
            storage.Delete(p1);

            // then reload it !
            LogicLayer.Directory d2 = storage.Load();

            // test if people ok
            var people = d2.ListContacts();
            Assert.Single(people);
            Assert.Equal(p2, people[0]);

            // clean up 
            RemoveFile();
            
        }
            
    }
}
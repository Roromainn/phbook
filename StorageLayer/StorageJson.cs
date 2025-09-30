using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Directory = LogicLayer.Directory;

namespace JsonStorage
{
    public class StorageJson : IStorage
    {
        private string file;
        private LogicLayer.Directory directory;

        public StorageJson(string path)
        {
            this.file = path;
            this.directory = new LogicLayer.Directory();
        }

        public Directory Load()
        {
            if (File.Exists(file))
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(LogicLayer.Directory), new Type[] { typeof(Person) });
                    this.directory = (LogicLayer.Directory)serializer.ReadObject(fs);
                }
            }
            else
            {
                this.directory = new LogicLayer.Directory();
                Save();
            }
            if (this.directory == null)
            {
                this.directory = new Directory();
            }


            return directory;
        }

        private void Save()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(LogicLayer.Directory), new Type[] { typeof(Person) });
                    serializer.WriteObject(ms, directory);

                    string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                    File.WriteAllText(file, jsonString);
                }

            }
            catch (Exception ex)
            {
                throw new StorageError();
            }
        }
        public IPerson Create()
        {
            return new Person("?", "");
        }

        public void Delete(IPerson p)
        {
            Save();
        }


        public void Update(IPerson p)
        {
            Save();
        }
    }
}

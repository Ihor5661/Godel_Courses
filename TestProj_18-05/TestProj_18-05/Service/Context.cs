using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestProj_18_05.Service
{
    internal class Context : IConnector
    {
        private readonly string path;
        private bool isConnect = false;

        public Context(string path) // "../../../../DB/User.json"
        {
            this.path = path;
        }

        public User Connect(string login)
        {
            isConnect = true;
            User user = null;

            if (CheckLoginExist(login))
            {
                //try
                //{
                //    var file = new FileStream(path + login + ".json", FileMode.Open);

                //    user = System.Text.Json.JsonSerializer.Deserialize<User>(file.ToString());
                //}
                //catch (Exception)
                //{
                //    user = null;
                //}
                var jsonFormatter = new DataContractJsonSerializer(typeof(User));

                using (var file = new FileStream(path + login + ".json", FileMode.Open)) // ToDo
                {
                    user = jsonFormatter.ReadObject(file) as User;
                }
            }

            return user;

        } // $"/{login}/" + //Directory.Exists

        public bool Disconnect()
        {

            isConnect = false;
            return true;
        }

        public bool SaveChanges(User user)
        {
            bool res;
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var jsonString = System.Text.Json.JsonSerializer.Serialize<object>(user, options);
                var fullPath = path + user.Login + ".json";
                File.WriteAllText(fullPath, jsonString);
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
           

            return res;

            //var jsonFormatter = new DataContractJsonSerializer(typeof(User));

            //if (user == null)
            //{
            //    return false;
            //}

            //using (var file = new FileStream(path + user.Login + ".json", FileMode.OpenOrCreate)) // ToDo // the path to the file 
            //{
            //    //file.Write(jsonString);
            //    jsonFormatter.WriteObject(file, user);
            //    return true;
            //}
        }

        public bool Connect(string host, string port)
        {
            isConnect = true;
            return true;
        }

        public bool Disconnect(string host, string port)
        {
            isConnect = false;
            return true;
        }

        private bool CheckLoginExist(string login)
        {
            string fullPath;

            fullPath = path + login + ".json";
            return File.Exists(fullPath);
        }

        public bool IsConnect
        {
            get { return isConnect; }
            private set { isConnect = value; }
        }
    }
}

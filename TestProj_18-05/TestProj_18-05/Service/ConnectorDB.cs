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
    internal class ConnectorDB : IConnectorDB
    {
        private readonly string path;

        public bool IsConnect
        {
            get;
            private set;
        }

        public ConnectorDB(string path) // "../../../../DB/User.json"
        {
            IsConnect = false;
            this.path = path;
        }

        ~ConnectorDB()
        {
            if (IsConnect)
            {
                Disconnect();
            }
        }

        public User Connect(string login)
        {
            IsConnect = true;
            User user = null;

            if (CheckLoginExist(login))
            {
                string json = File.ReadAllText(path + login + ".json");
                user = JsonConvert.DeserializeObject<User>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                });

            }

            return user;
        }

        public bool Disconnect()
        {
            IsConnect = false;
            return true;
        }

        public bool SaveChanges(User user)
        {
            bool res;
            try
            {
                var jsonString = JsonConvert.SerializeObject(user, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                });
                var fullPath = path + user.Login + ".json";
                File.WriteAllText(fullPath, jsonString);

                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
           

            return res;
        }

        public bool Connect(string host, string port)
        {
            IsConnect = true;
            return true;
        }

        public bool Disconnect(string host, string port)
        {
            IsConnect = false;
            return true;
        }

        private bool CheckLoginExist(string login)
        {
            string fullPath;

            fullPath = path + login + ".json";
            return File.Exists(fullPath);
        }
    }
}

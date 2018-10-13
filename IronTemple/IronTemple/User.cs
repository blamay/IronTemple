using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IronTemple
{
    public class User
    {
        // workoutHistory

        public string Name;

        public User(string name)
        {
            Name = name;
        }

        public static User CreateUserFromXml()
        {
            string xmlUserData = "UserData.xml";

            try
            {
                XmlDocument userData = new XmlDocument();
                userData.Load(xmlUserData);

                string name = Convert.ToString(userData.SelectSingleNode("/User/Name").InnerText);

                User user = new User(name);

                return user;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                User user = new User("bob");
                //throw;

                return user;
            }
        }

    }
}

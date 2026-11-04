using OOP_Project.ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.RepositoryLayer
{
    public class AdminRepository
    {
        private readonly string _filePath = "D:\\2nd Semester\\OOP\\OOP Project\\OOP Project\\RepositoryLayer\\Admin.txt";

        public void Save(Admin admin)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(admin.ToString());
            }
        }

        public void SaveAll(List<Admin> admin)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                foreach (var admins in admin)
                {
                    writer.WriteLine(admin.ToString());
                }
            }
        }
        public List<Admin> GetAll()
        {
            List<Admin> admin = new List<Admin>();
            Admin a = new Admin();
            StreamReader writer = new StreamReader(_filePath);
            string record;
            while ((record = writer.ReadLine()) != null)
            {
                a.Username = getField(record, 1);
                a.Password = getField(record, 2);
                admin.Add(new Admin(a.Username, a.Password));
            }
            writer.Close();
            return admin;
        }

        public string getField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }


        public void ClearAll()
        {
            File.WriteAllText(_filePath, string.Empty);
        }
    }
}

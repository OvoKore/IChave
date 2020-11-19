using System;
using System.Text.RegularExpressions;
using IChave.Validators;

namespace IChave.Models
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string cell_phone { get; set; }
        public string cpf { get; set; }
        public string sex { get; set; }
        public DateTime birthdate { get; set; }

        public User()
        {
        }

        public User(UserVal _user)
        {
            name = _user.name;
            cpf = Regex.Replace(_user.cpf, "([.]|/|-)", "");
            cell_phone = Regex.Replace(_user.cell_phone, "([(]|[)]|-)", "");
            sex = _user.sex;
            birthdate = _user.birthdate;
            email = _user.email.ToLower();
            password = Utils.Crypt(_user.password);
        }
    }
}
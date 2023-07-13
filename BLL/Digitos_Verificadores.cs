using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public static class Digitos_Verificadores
    {

        public static bool CheckDvTable(string table)
        {
            DVS dvs = new DVS();            
            string calculatedDVV = SecurityBLL.CalculateMD5Hash(dvs.Gettabledvs(table));
            byte [] totalDvvFromTable = dvs.GetDvfromtable(table);
            string tableDVV = Encoding.ASCII.GetString(totalDvvFromTable);

            if (calculatedDVV == tableDVV)
            {
                return true;
            }

            return false;
        }

        public static User CheckDvh()
        {
            DVS dvs = new DVS();
            UserDAL userdal = new UserDAL();
            List<User> usersList = userdal.GetAll();

            foreach (User user in usersList)
            {
                string st = user.id.ToString()+user.username.ToString()+ user.email.ToString() + user.password.ToString() + user.userType.ToString();
                byte[] hash = Encoding.ASCII.GetBytes(SecurityBLL.CalculateMD5Hash(st));
                string b64hash = Convert.ToBase64String(hash);
                string b64userdvh = Convert.ToBase64String(user.dvh);


                if (b64hash != b64userdvh)
                {
                    return user;
                }
            }
            return null;
             
            /**
            string calculatedDVV = SecurityBLL.CalculateMD5Hash(dvs.Gettabledvs(table));
            byte[] totalDvvFromTable = dvs.GetDvfromtable(table);
            string tableDVV = Encoding.ASCII.GetString(totalDvvFromTable);

            if (calculatedDVV == tableDVV)
            {
                return true;
            }

            return false;
            **/
        }



    }
}

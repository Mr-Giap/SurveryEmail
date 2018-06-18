using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer.BLL
{
    public class Encrypt 
    {
        public static string sha1 (string code)
        {
            return Encryptor.sha1(code);
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DopplerAPI.Authentication
{
    public class TokenAuth
    {
        public const string Issuer = "DopplerServer";
        public const string Audience = "DopplerUsers";
        private const string Key = "q3prkaw09jt30qi3jtaewjkf3m58309ij34095jn34";
        public const int Lifetime = 20;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}

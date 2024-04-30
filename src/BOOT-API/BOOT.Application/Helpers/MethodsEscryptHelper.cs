
using BOOT.Utilities.Helpers;
using Microsoft.Extensions.Configuration;

namespace BOOT.Application.Helpers
{
    public class MethodsEscryptHelper
    {
        public string EncryptPassword(string value)
        {
            var SectionKey = (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("passwordEncrypt"));
            var EncryptH = new EncryptorHelper
            {
                Enckey = SectionKey.GetValue<string>("Key"),
                EncMacKey = SectionKey.GetValue<string>("macKey"),
            };
            return EncryptH.EncryptValue(value);
        }

        public string DencryptPassword(string value)
        {
            var SectionKey = (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("passwordEncrypt"));
            var EncryptH = new EncryptorHelper
            {
                Enckey = SectionKey.GetValue<string>("Key"),
                EncMacKey = SectionKey.GetValue<string>("macKey"),
            };
            return EncryptH.DEncryptValue(value);
        }

        public string EncryptToken(string value)
        {
            var SectionKey = (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("tokenSession"));
            var EncryptH = new EncryptorHelper
            {
                Enckey = SectionKey.GetValue<string>("Key"),
                EncMacKey = SectionKey.GetValue<string>("macKey"),
            };
            return EncryptH.EncryptValue(value);
        }

        public string DencryptToken(string value)
        {
            var SectionKey = (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("tokenSession"));
            var EncryptH = new EncryptorHelper
            {
                Enckey = SectionKey.GetValue<string>("Key"),
                EncMacKey = SectionKey.GetValue<string>("macKey"),
            };
            return EncryptH.DEncryptValue(value);
        }
    }
}

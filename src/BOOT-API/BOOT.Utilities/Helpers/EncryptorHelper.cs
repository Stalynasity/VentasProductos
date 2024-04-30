using ApiPolizasElectronicas.Models.Complementos;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using System.Text;

namespace BOOT.Utilities.Helpers
{
    public class EncryptorHelper
    {
        public string Enckey { get; set; }
        public string EncMacKey { get; set; }


        public string EncryptValue(string Value)
        {
            var Aes= new Encryptor<AesEngine, Sha256Digest>(Encoding.UTF8, Encoding.UTF8.GetBytes(Enckey), Encoding.UTF8.GetBytes(EncMacKey));
            return Aes.Encrypt(Value);
        }

        public string DEncryptValue(string Value)
        {
            var Aes = new Encryptor<AesEngine, Sha256Digest>(Encoding.UTF8, Encoding.UTF8.GetBytes(Enckey), Encoding.UTF8.GetBytes(EncMacKey));
            return Aes.Decrypt(Value);
        }
    }
}

using BOOT.Application.Commons.General;
using Microsoft.Extensions.Configuration;

namespace BOOT.Application.Helpers
{
    public class MethodsHelper
    {
        public string ConverDateTimeToString(DateTime dateTime)
        {
            var dateTimeFormat = (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("formatDateTime")).Value;
            return dateTime.ToString(dateTimeFormat);
        }

        public DateTime ConveStringToDateTime(string dateTime)
        {
            var dateTimeFormat = (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("formatDateTime")).Value;
            return DateTime.ParseExact(dateTime, dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
        }

        public string CreateTokenSesion(int userId)
        {
            var secondsValidate = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("tokenSession").GetValue<int>("secondsValidate");

            var ModelTokerSesion = new TokerSessionModel
            {
                Userid = userId,
                DataExpired = ConverDateTimeToString(DateTime.Now.AddSeconds(secondsValidate)),
            };

            var EncrypMet = new MethodsEscryptHelper();
            return EncrypMet.EncryptToken(ModelTokerSesion.ToJson());
        }

        public string? ValidateTokenSesion(string token)
        {
            try
            {
                TokerSessionModel? modelSesion = GetModelSesionByToken(token);


                if (DateTime.Now.CompareTo(ConveStringToDateTime(modelSesion.DataExpired)) < 0)
                {
                    return null;
                }
                else
                {
                    return "Session Expirada";
                }
            }
            catch (Exception ex)
            {
                return "Token invalido";
            }
        }

        public TokerSessionModel? GetModelSesionByToken(string token)
        {

            var EncrypMet = new MethodsEscryptHelper();
            var ModelSesionString = EncrypMet.DencryptToken(token);

            var modelSesion = TokerSessionModel.FromJson(ModelSesionString);

            return modelSesion;


        }


    }
}

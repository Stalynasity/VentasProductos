namespace BOOT.Utilities.Static
{
    public class ReplyMessage
    {
        public const string MESSAGE_QUERY = "Consulta Exitosa.";
        public const string MESSAGE_QUERY_EMPTY = "No se encontraron registro.";
        public const string MESSAGE_SAVE = "Se registro correctamente.";
        public const string MESSAGE_UPDATE = "Se actualizo correctamente";
        public const string MESSAGE_DELETE = "Se elimino correctamente";
        public const string MESSAGE_EXISTS = "El registro ya existe.";
        public const string MESSAGE_ACTIVATE = "El registro ha sido activado.";
        public const string MESSAGE_TOKEN = "Token generado correctamente.";
        public const string MESSAGE_TOKEN_ERROR = "EL usuario o comtraseña es incorrecto, compruebala";
        public const string MESSAGE_ERR_VALIDATE = "Errores de validacion.";
        public const string MESSAGE_FAILED = "Operacion fallida.";

        public static string ErrorCreateInvoice = "Error, no se pudo facturar el pedido";
        public static string ErrorCreateInvoiceProductNotFound = "Error, no existe";
        public static string ErrorCreateInvoiceProductExecendStock = "Error, uno o mas productos excede el stock existente";

        public static string LoginErrorUserName = "Usuario Incorrecto";
        public static string LoginErrorPoss = "contraseña Incorrecto";
        public static string LoginErrorNotActived = "Usuario Deshabilitado";

        public static string TokenSesionErrorValidate = "La sesion no es valida";
        public static string TokenSesionErrorExpired = "La sesion ah caducado";
        public static string TokenSesionErrorNotParams = "No se encontro el token de sesion";

        public static string RegisterUserErrorExisterUser = "Error, El usuario ya existe intente otro";
        public static string RegisterUserErrorEx = "Ocurrio un error al ingresar el usuario";
        public static string RegisterUserErrorParamUserName = "Usuario debe tener de minimo 4 a 16 maximo caracteres";
        public static string RegisterUserErrorParamPassword = "Contraseña debe tener de minimo 4 a 16 maximo caracteres";

        public static string ChangePasswordErrorId = "Ocurrio un error al buscar al usuario";
        public static string ChangePasswordErrorPaswword = "La contraseña anterior no existe";
        public static string ChangePasswordErrorEx = "Ocurrio un error al realizar el cambio de contraseña";

        public static string GetInvoiceErrorHead = "Ocurrio un error al consultar las facturas";
        public static string GetInvoiceErrorDetail = "Ocurrio un error al consultar el detalle de la factura";
        public static string GetInvoiceErrorDetailNotUser = "No tienes acceso a ver el detalle de esta factura u ocurrio un error";

    }
}

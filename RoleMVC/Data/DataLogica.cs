using RoleMVC.Models;
namespace RoleMVC.Data
{
    public class DataLogica
    {
        //simulacion de las consultas a la base de datos
        public List<Usuario> listaUsuario() {
            return new List<Usuario>
            {
                new Usuario{Nombre="Eric", Correo="administrador@gmail.com", Clave="1234",Roles=new string[]{"administrador" }},
            new Usuario { Nombre = "Nayade", Correo = "supervisor@gmail.com", Clave = "1234", Roles = new string[] { "supervisor" } },
            new Usuario { Nombre = "Eric", Correo = "empleado@gmail.com", Clave = "1234", Roles = new string[] { "empleado" } },
            new Usuario { Nombre = "Eric", Correo = "superempleado@gmail.com", Clave = "1234", Roles = new string[] { "supervisor","empleado" } }
            };
        }
        //Para saber si el usuario que esta ingresando existe en nuestras tablas
        public Usuario validarUsuario(string correo, string clave) {

            return listaUsuario().Where(item => item.Correo == correo && item.Clave==clave).FirstOrDefault()  ;
        }
    }
}

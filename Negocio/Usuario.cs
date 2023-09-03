﻿// Contiene las acciones de negocio. Las clases sin atributos, solo con acciones
// Acá va a estar la clase usuario con todas sus acciones
// Por ejemplo: la clase usuario con el metodo crearUsuario
// Realiza las validaciones de negocio (las validaciones especificas de cada clase)
// El método crearUsuario crea una instancia de la clase Usuario de la capa de Modelo
// Ve a las otras dos capas
namespace Negocio
{
    public class Usuario
    {
        //Lautaro
        // debe tener un método CrearUsuario que recibe los parametros necesarios para la creación
        // CrearUsuario tiene que llamar a otro método ValidarUsuario que valide que el nombre de usuarios cumpla los requisitos
        // Llama al método ValidarUsuario para verificar si el nombre de usuario cumple con los requisitos


        public UsuarioModel CrearUsuario(string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
        {
            while (!ValidarUsuario(usuario, nombre, apellido))
            {
                Console.WriteLine("El nombre de usuario no cumple con los requisitos.\nPor favor, ingrese uno válido.");
                usuario = Console.ReadLine(); // Pedir nuevamente el nombre de usuario
            }
            // Crea una instancia de UsuarioModel
            UsuarioModel nuevoUsuario = new UsuarioModel(nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);

            // Retorna el usuario creado
            return nuevoUsuario;
        }

           private bool ValidarUsuario(string usuario, string nombre, string apellido)
        {
            // Normalizacion para que no haya problemas con las mayusculas/minusculas
            usuario = usuario.ToLower();
            nombre = nombre.ToLower();
            apellido = apellido.ToLower();

            // Validación del nombre de usuario. Verifica si tiene entre 8 y 15 caracteres y no contiene el nombre o apellido del usuario.
            bool cumpleRequisitos = usuario.Length >= 8 && usuario.Length <= 15 && !usuario.Contains(nombre) && !usuario.Contains(apellido);

            return cumpleRequisitos;
        }

        // Otro método login que permita iniciar sesión con el nombre de usuario y la contraseña. En este caso, si es el primer login
        // debe solicitar cambiar la contraseña y el estado del usuario (capa Modelo) pasará a ser ACTIVO
        // Otro método SolicitarContrasenia que pida una nueva contraseña y la guarde
        // SolicitarContrasenia va a llamar al método ValidarContrasenia que verifique que cumpla los requisitos
        // Cuando el usuario se quiera registrar, se deberá chequear hace cuanto cambio la contraseña, si pasaron 30 días o más
        // se deberá llamar nuevamente al método SolicitarContrasenia (chequeando que la nueva contraseña no sea igual a la anterior)
    }
}

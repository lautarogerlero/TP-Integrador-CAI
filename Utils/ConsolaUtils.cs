// Parte de la capa de Presentación
// Contiene las validaciones generales

using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace Utils
{
    public class ConsolaUtils
    {
        public static string PedirString(string msg)
        {
            // Método para pedir un string
            Console.WriteLine(msg);
            string valor = Console.ReadLine();

            return valor;
        }

        public static int PedirInt(string msg)
        {
            // Método para pedir un int y verificar que sea un int
            int valor;
            bool esNumero;
            do
            {
                Console.WriteLine(msg);
                esNumero = int.TryParse(Console.ReadLine(), out valor);
                if (!esNumero)
                {
                    Console.WriteLine("Por favor ingrese un número. ");
                }
            } while (!esNumero);

            return valor;
        }

        public static int PedirHost(string msg)
        {
            // Metódo para verificar que el int sea 2 o 3
            int host;
            bool hostValido;
            do
            {
                host = PedirInt(msg);
                hostValido = host == 2 || host == 3;
                if (!hostValido)
                {
                    Console.WriteLine("Ingrese un host válido (2 o 3)");
                }
            } while (!hostValido);
            return host;
        }

        public static int PedirIntRango(string msg, int min, int max)
        {
            int valor;
            bool valorValido;
            do
            {
                valor = PedirInt(msg);
                valorValido = valor >= min && valor <= max;
                if (!valorValido)
                {
                    Console.WriteLine("Valor fuera de rango");
                }
            } while (!valorValido);
            return valor;
        }

        public static DateTime PedirFecha(string msg)
        {
            // Método para pedir una fecha y verificar que esté en formato fecha
            DateTime valor;
            bool esFechaValida;

            do
            {
                Console.WriteLine(msg + " con el formato dd/MM/yyyy");
                esFechaValida = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out valor);

                if (!esFechaValida)
                {
                    Console.WriteLine("Fecha no válida.");
                }
            } while (!esFechaValida);

            return valor;
        }

        public static string ValidarNombre(string msg)
        {
            string nombre;
            bool nombreValido;
            do
            {
                nombre = PedirString(msg);
                // Chequear que el nombre tenga más de 2 caracteres y solo contenga letras
                nombreValido = nombre.Length > 2 && Regex.IsMatch(nombre, @"^[a-zA-Z]+$");
                if (!nombreValido)
                {
                    Console.WriteLine("Nombre inválido");
                }
            } while (!nombreValido);

            // Convertir la primera letra a mayúscula y las demas a minúscula
            nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre.ToLower());

            return nombre;
        }

        public static int ValidarDni(string msg)
        {
            int dni;
            bool dniValido;
            do
            {
                dni = PedirInt(msg);
                // Verificar que el DNI tenga 8 números o más
                dniValido = dni.ToString().Length <= 8;
                if (!dniValido)
                {
                    Console.WriteLine("DNI inválido.");
                }
            } while (!dniValido);

            return dni;
        }

        public static DateTime ValidarFechaNacimiento(string msg)
        {
            DateTime fechaNacimiento;
            bool fechaNacimientoValido;
            do
            {
                fechaNacimiento = PedirFecha(msg);
                // Verificar que la fecha de nacimiento no sea antes del 1/1/1999 y no sea después de la fecha de hoy menos 10 años.
                DateTime fechaMinima = new DateTime(1900, 1, 1);
                DateTime fechaHoy = DateTime.Now;
                DateTime fechaMaxima = fechaHoy.AddYears(-10); // Restarle 10 años a la fecha de hoy
                fechaNacimientoValido = fechaNacimiento >= fechaMinima && fechaNacimiento < fechaMaxima;
                if (!fechaNacimientoValido)
                {
                    Console.WriteLine("Fecha de nacimiento inválida");
                }
            } while (!fechaNacimientoValido);

            return fechaNacimiento;
        }

        public static string ValidarEmail(string msg)
        {
            bool emailValido;
            string email;
            do
            {
                email = PedirString(msg);
                // Verificar que la dirección de correo no tenga espacios, contenga un "@" y termine en ".com"
                emailValido = !email.Contains(" ") && email.Count(c => c == '@') == 1 && email.EndsWith(".com");
                if (!emailValido)
                {
                    Console.WriteLine("Dirección de correo inválida.\nIngrese una dirección valida: ");
                }
            } while (!emailValido);

            return email;
        }

        public static string ValidarTelefono(string msg)
        {
            bool telefonoValido;
            string telefono;
            do
            {
                telefono = PedirString(msg);
                string patron = @"^\d{8,}$"; // Chequear que haya al menos 8 caracteres y sean numeros
                telefonoValido = Regex.IsMatch(telefono, patron);
                if (!telefonoValido)
                {
                    Console.WriteLine("Teléfono no válido");
                }
            } while (!telefonoValido);

            return telefono;
        }

        public static List<int> PedirListaNumeros(string msg) // Pide una lista de números del 1 al 5
        {
            List<int> lista = new List<int>();

            while (lista.Count < 5)
            {
                Console.WriteLine(msg);
                string numero = Console.ReadLine();
                if (numero.ToUpper() == "X")
                {
                    break;
                }
                else if (int.TryParse(numero, out int numeroFinal))
                {
                    if (numeroFinal >= 1 && numeroFinal <= 5)
                    {
                        if (!lista.Contains(numeroFinal)) // Verifica si el número ya está en la lista.
                        {
                            lista.Add(numeroFinal);
                        }
                        else
                        {
                            Console.WriteLine("El número ya está en la lista.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El número debe ser entre 1 y 5");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida");
                }
            }
            return lista;
        }

    }
}
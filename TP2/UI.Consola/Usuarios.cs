using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _usuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _usuarioNegocio; }
            set { _usuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            ConsoleKeyInfo opcion;

            do
            {
                Console.WriteLine("\nElija una opción");
                Console.WriteLine("1 - Listado general");
                Console.WriteLine("2 - Consulta");
                Console.WriteLine("3 - Agregar");
                Console.WriteLine("4 - Modificar");
                Console.WriteLine("5 - Eliminar");
                Console.WriteLine("6 - Salir");
                
                opcion = Console.ReadKey();

                switch (opcion.Key)
                {
                    case ConsoleKey.D1:
                        this.ListadoGeneral();
                        break;

                    case ConsoleKey.D2:
                        this.Consultar();
                        break;

                    case ConsoleKey.D3:
                        this.Agregar();
                        break; 

                    case ConsoleKey.D4:
                        this.Modificar();
                        break;

                    case ConsoleKey.D5:
                        this.Eliminar();
                        break;
                }
            } while (!opcion.Key.Equals(ConsoleKey.D6));
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.Id);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            //Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine(fe.Message);
                Console.WriteLine("La ID ingresada debe ser un numero entero.");
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();

            Console.Write("Ingrese nombre: ");
            Console.Write("Ingrese apellido: ");
            Console.Write("Ingrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();

            Console.Write("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();

            /*Console.Write("Ingrese email: ");
            usuario.Email = Console.ReadLine();*/

            Console.Write("Ingrese Habilitación de usuario (1-Si / otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");

            usuario.State = BusinessEntity.States.New;

            UsuarioNegocio.Save(usuario);

            Console.WriteLine();
            Console.WriteLine("Se agregó el ID: {0}", usuario.Id);
            Console.WriteLine("Presione cualquier tecla para volver al menu.");
            Console.ReadKey();
            Console.Clear();
        } 
        
        public void Modificar()
        {
            try
            {
                Console.Clear();
                
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int id = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(id);

                Console.Write("Ingrese nombre: ");
                Console.Write("Ingrese apellido: ");

                Console.Write("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();

                Console.Write("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();

                /*Console.Write("Ingrese email: ");
                usuario.Email = Console.ReadLine();*/

                Console.Write("Ingrese Habilitación de usuario (1-Si / otro-No): ");
                usuario.Habilitado = (Console.ReadLine()=="1");

                usuario.State = BusinessEntity.States.Modified;

                UsuarioNegocio.Save(usuario);
            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine(fe.Message);
                Console.WriteLine("La ID ingresada debe ser un numero entero.");
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(id);
            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine(fe.Message);
                Console.WriteLine("La clave ingresada debe ser un numero entero.");
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

    }
}

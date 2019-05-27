﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using PrototipoLIINS.Modelo;

namespace PrototipoLIINS.Conexion
{
    public class UsuarioRepository
    {
        private SQLiteConnection con;

        private static UsuarioRepository instancia;
        public static UsuarioRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al Inicializador");
                return instancia;
            }
        }

        public static void Inicializador(String filename)
        {
            if (filename == null)
                throw new ArgumentNullException();

            if (instancia != null)
                instancia.con.Close();

            instancia = new UsuarioRepository(filename);
        }

        private UsuarioRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);

            con.CreateTable<Usuario>();
        }

        public string EstadoMensaje;

        public void AddNuevoUsuario(string email, string contraseña, string nombre, string apellido, string tipo, string estado)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Usuario()
                {
                    Email = email,
                    Contraseña = contraseña,
                    Nombre = nombre,
                    Apellido = apellido,
                    Tipo = tipo,
                    Estado = estado
                });

                EstadoMensaje = string.Format("{0} Nuevo usuario añadido", result);
            } catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            try
            {
                return con.Table<Usuario>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }

    }
}
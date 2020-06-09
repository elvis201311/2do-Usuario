using _2do_Usuario.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _2do_Usuario.BLL
{
     public class UsuariosBLL
        {
            //Metodo Existe
            public static bool Existe(int Id)
            {
                Contexto contexto = new Contexto();
                bool encontrado = false;

                try
                {
                    encontrado = contexto.Usuarios.Any(encontrado => encontrado.UsuarioId == Id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return encontrado;
            }

            //Metodo Insertar 
            private static bool Insertar(Entidades.Usuarios usuarios)
            {
                bool key = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Usuarios.Add(usuarios);
                    key = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return key;
            }

            //Metodo Modificar.
            private static bool Modificar(Entidades.Usuarios usuarios)
            {
                bool key = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Entry(usuarios).State = EntityState.Modified;
                    key = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return key;
            }

            //Metodo Guardar.
            public static bool Guardar(Entidades.Usuarios usuarios)
            {
                if (!Existe(usuarios.UsuarioId))
                {
                    return Insertar(usuarios);
                }
                else
                {
                    return Modificar(usuarios);
                }
            }

            //Metodo Eliminar.
            public static bool Eliminar(int Id)
            {
                bool key = false;
                Contexto contexto = new Contexto();

                try
                {
                    var usuarios = contexto.Usuarios.Find(Id);

                    if (usuarios != null)
                    {
                        contexto.Usuarios.Remove(usuarios);
                        key = contexto.SaveChanges() > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return key;
            }

            //Metodo Buscar.
            public static Entidades.Usuarios Buscar(int Id)
            {
                Contexto contexto = new Contexto();
                Entidades.Usuarios usuarios;

                try
                {
                    usuarios = contexto.Usuarios.Find(Id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return usuarios;
            }

            //Metodo Lista.
            public static List<Entidades.Usuarios> GetList(Expression<Func<Entidades.Usuarios, bool>> criterio)
            {
                List<Entidades.Usuarios> lista = new List<Entidades.Usuarios>();
                Contexto contexto = new Contexto();

                try
                {
                    lista = contexto.Usuarios.Where(criterio).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return lista;
            }
        }
    }

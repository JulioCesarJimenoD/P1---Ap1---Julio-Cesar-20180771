using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1___Ap1___Julio_Cesar_20180771.DAL;
using Microsoft.EntityFrameworkCore;
using P1___Ap1___Julio_Cesar_20180771.UI.Registro;
using P1___Ap1___Julio_Cesar_20180771.Entidades;
using System.Linq.Expressions;

namespace P1___Ap1___Julio_Cesar_20180771.BLL
{
   public class AporteBLL
    {
        public static bool Existente(int id)
        {
            Contexto contexto = new Contexto();
            bool existente = false;
            try
            {
                existente = contexto.aportes.Any(async => async.AporteId == id);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return existente;

        }

        public static bool Insertar (Aportes aportes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.aportes.Add(aportes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificiar(Aportes aportes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(aportes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

      

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var aportes = contexto.aportes.Find(id);
                if (aportes != null)
                {
                    contexto.aportes.Remove(aportes);
                    paso = contexto.SaveChanges() > 0;
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
            return paso;
        }
        public static bool Guardar(Aportes aportes)
        {
            if (!Existente(aportes.AporteId))
            {
                return Insertar(aportes);
            }
            else
            {
                return Modificiar(aportes);
            }
        }

        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes aportes;

            try
            {
                aportes = contexto.aportes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return aportes;
        }

        public static List <Aportes> GetList(Expression<Func<Aportes, bool>> cristerio)
        {
            List<Aportes> listado = new List<Aportes>();
            Contexto contexto = new Contexto();

            try
            {
                listado = contexto.aportes.Where(cristerio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listado;
        }

        public static List<Aportes> GetAportes()
        {
            List<Aportes> listados = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                listados = contexto.aportes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }return listados;
        }
    }
}

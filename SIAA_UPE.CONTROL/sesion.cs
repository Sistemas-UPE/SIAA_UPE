using System;
using System.Collections.Generic;
using System.Linq;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class sesion
    {
        DBDataContext db = new DBDataContext();

        public string login(string _user, string _pass)
        {
            string permiso = "";
            try
            {
                FD_SIA_ALUMNO alumnoF = alumnoLog(_user,_pass);
                FD_SIA_EMPLEADO empleadoF = empleadoLog(_user,_pass);
                FD_SIA_DOCENTE docenteF = docenteLog(_user,_pass);


                if (alumnoF != null)
                {
                string estado = alumnoF.idSituacionActual;

                    permiso = "Alumno";
                    if (estado.Equals("1         "))
                    {
                        return permiso;
                    }
                    else
                    {
                        return permiso + " INACTIVO";
                    }
                }
                else if (empleadoF != null)
                {
                    permiso = empleadoF.CT_SIA_ROL.rol;
                    return permiso;
                }
                else if (docenteF != null)
                {
                    permiso = "Docente";
                    return permiso;
                }
                else
                {
                    return "Sin registro";
                }
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return "Sin registro";
            }
        }

        private FD_SIA_ALUMNO alumnoLog(string _user, string _pass)
        {
            try
            {
                FD_SIA_ALUMNO alumnoF = db.FD_SIA_ALUMNO.Where(p => p.idAlumno == _user && p.password == _pass).First();
                return alumnoF;

            }
            catch (Exception e)
            {
                string m = e.Message;

                return null;
            }
        }
        private FD_SIA_EMPLEADO empleadoLog(string _user, string _pass)
        {
            try
            {
                FD_SIA_EMPLEADO empleadoF = db.FD_SIA_EMPLEADO.Where(p => p.idEmpleado == _user && p.password == _pass).First();
              
                
                
                return empleadoF;
            }
            catch (Exception e)
            {
                string m = e.Message;
                return null;
            }
        }
        private FD_SIA_DOCENTE docenteLog(string _user, string _pass)
        {
            try
            {
                FD_SIA_DOCENTE docenteF = db.FD_SIA_DOCENTE.Where(p => p.idDocente == _user && p.password == _pass).First();
                return docenteF;

            }
            catch (Exception e)
            {
                string m = e.Message;
                return null;
            }
        }
        public List<CT_SIA_ROL> selectRol()
        {
            try
            {
                return db.CT_SIA_ROL.ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public string genPassword()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%|$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }

    }
}

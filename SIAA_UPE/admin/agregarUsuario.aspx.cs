using System;
using System.Text.RegularExpressions;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.admin
{
    public partial class agregarUsuario : System.Web.UI.Page
    {
        sesion ses = new sesion();
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlPersona ctrlP = new ctrlPersona();
        ctrlAlumno ctrlA = new ctrlAlumno();
        ctrlDocente ctrlD = new ctrlDocente();
        ctrlGrupo ctrlG = new ctrlGrupo();
        ctrlEmpleado ctrlE = new ctrlEmpleado();
        FD_SIA_DOCENTE docente = new FD_SIA_DOCENTE();
        DP_SIA_PERSONA persona = new DP_SIA_PERSONA();
        FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        FD_SIA_EMPLEADO empleado = new FD_SIA_EMPLEADO();
        DP_SIA_DOMICILIO direc = new DP_SIA_DOMICILIO();
        DP_SIA_TUTOR t = new DP_SIA_TUTOR();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenar();
            }
            this.idImprimeme.Visible = false;
        }

        protected void ddRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Visible = true;
            switch (ddRol.SelectedValue)
            {
                case "1":
                    divPersona.Visible = true;
                    divEmpleado.Visible = true;
                    divAlumno.Visible = false;
                    break;
                case "2":
                    divPersona.Visible = true;
                    divEmpleado.Visible = true;
                    divAlumno.Visible = false;
                    break;
                case "3":
                    divPersona.Visible = true;
                    divEmpleado.Visible = true;
                    divAlumno.Visible = false;
                    break; 
                case "4":
                    divPersona.Visible = true;
                    divEmpleado.Visible = true;
                    divAlumno.Visible = false;
                    break;
                case "5":
                    divPersona.Visible = true;
                    divAlumno.Visible = true;
                    divEmpleado.Visible = false;

                    break;

                default:
                    this.btnGuardar.Visible = false;
                    divPersona.Visible = false;
                    divAlumno.Visible = false;
                    break;
            }
        }


        /////////////////METODOS LOCALES/////////////////
        private void llenar()
        {
            ddRol.DataSource = ses.selectRol();
            ddRol.DataBind();
            ddRol.Items.Insert(0, "Seleccione el tipo de Usuario a registrar");
            ddCarrera.DataSource = ctrlC.selectSinMM();
            ddCarrera.DataBind();
            ddCarrera.Items.Insert(0, "Seleccione la carrera que sea de tu interés");
            ddEstado.DataSource = ctrlP.estados();
            ddEstado.DataBind();
            ddEstado.Items.Insert(0, "Seleccione tu estado");
            ddEstadoT.DataSource = ctrlP.estados();
            ddEstadoT.DataBind();
            ddEstadoT.Items.Insert(0, "Seleccione tu estado");
            ddInstituto.DataSource = ctrlA.instituciones();
            ddInstituto.DataBind();
            ddInstituto.Items.Insert(0, "Seleccione tu Bachillerato del cual Egresas");
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try { 
                int rol = int.Parse(ddRol.SelectedValue);
                persona.nombre = txtName.Text;
                persona.aPaterno = txtLName.Text;
                persona.aMaterno = txtSName.Text;
                persona.CURP = txtCURPR.Text;
                persona.cElectronico = txtCE.Text;
                persona.fNacimiento = DateTime.Parse(txtCalendario.Text);
                persona.sexo = rbSexo.SelectedItem.Value;
                persona.discapacidad = rbDisca.SelectedItem.Value;
                persona.nTelefonicoCel = txtNTP.Text;
                direc.calle = txtCALLE.Text;
                direc.colonia = txtCOLONIA.Text;
                direc.municipio = txtMUNICIPIO.Text;
                direc.Localidad = txtLC.Text;
                direc.nExterno = txtNUMEROEX.Text;
                direc.nInterno = txtNUMEROIN.Text;
                direc.cp = int.Parse(txtCP.Text);
                direc.idEstado = int.Parse(ddEstado.SelectedValue);
                //persona.idDireccion = ctrlP.insertDireccionUltimo(direc);

                string grupo = Regex.Replace(ddCarrera.SelectedValue + ddGrupo.SelectedItem, @"\s+", String.Empty);
                //int idP = ctrlP.insertUltimo(persona);
                int idP = 1;
                string password = ses.genPassword();
                switch (rol)
                {
                    case 4:
                        docente.idPersona = idP;

                        break;

                    case 5:
                        alumno.idAlumno = txtID.Text.Substring(4);
                        alumno.idPersona = idP;
                        alumno.idGrupo = ddGrupo.SelectedValue;
                        alumno.generacion = int.Parse(txtID.Text.Substring(0, 4));
                        alumno.fIngreso = DateTime.Parse(txtFDI.Text);
                        alumno.idSituacionActual = "1";
                        alumno.password = password;
                        alumno.pInd = rbIndigena.SelectedItem.Value;
                        alumno.nSeguro = txtNSS.Text;
                        alumno.promedio = txtPROMEDIO.Text;
                        persona.nombre = txtNCT.Text;
                        persona.aPaterno = txtAPP.Text;
                        persona.aMaterno = txtAPM.Text;
                        persona.cElectronico = txtCORREOT.Text;
                        persona.fNacimiento = DateTime.Parse(txtFechaNaT.Text);
                        persona.sexo = rbsexot.SelectedItem.Value;
                        persona.discapacidad = rdDisT.SelectedItem.Value;
                        persona.nTelefonicoCel = txtNTPT.Text;
                        direc.calle = txtCALLET.Text;
                        direc.colonia = txtCOLONIAT.Text;
                        direc.municipio = txtMUNIT.Text;
                        direc.Localidad = txtLOCT.Text;
                        direc.idEstado = int.Parse(ddEstadoT.SelectedValue);
                        direc.cp = int.Parse(txtCPT.Text);
                        direc.nExterno = txtNUMEXT.Text;
                        direc.nInterno = txtNUMINT.Text;
                        //persona.idDireccion = ctrlP.insertDireccionUltimo(direc);
                        t.idPersona = ctrlP.Ultimo();

                        if (alumno.idTutor == null)
                        {
                            //ctrlP.insertDireccion(direc);
                            //tutor.idDireccion = ctrlP.Ultimodir();
                            //ctrlP.insert(persona);
                            //alumno.idTutor = ctrlP.inserttutor(t);
                            //alumno.intEVCD = 3;
                            //alumno.idModalidad = 1;
                            //alumno.nSeguro = txtPROMEDIO.Text;
                            //ctrlAl.insertAlumno(alumno);
                        }
                        break;
                    default:
                        
                        empleado.idEmpleado = txtIdEmpleado.Text;
                        empleado.idPersona = idP;
                        empleado.departamento = txtDepartamento.Text;
                        empleado.idRol = rol;
                        empleado.area = ddRol.SelectedItem.Text;
                        empleado.horario = ddHorario.SelectedItem.Text;
                        empleado.gAcademico = ddGradoAcademico.SelectedItem.Text;
                        empleado.password = password;
                        empleado.RFC = txtRFC.Text;
                        empleado.NS = txtNSS.Text;
                        lbUsuario.Text = txtIdEmpleado.Text;
                        lbPassword.Text = password;
                        //ctrlE.insert(empleado);
                        break;

                }
                this.idImprimeme.Visible = true;
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                lbErrorRe.Text = "Ocurrio un Error, al procesar su información por favor revise que haya completado todos los registros";
            }
        }

        protected void btnX_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/agregarUsuario.aspx");
        }
    }
}
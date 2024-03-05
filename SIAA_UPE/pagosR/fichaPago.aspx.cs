using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAA_UPE.pagosR
{
    public partial class fichaPago1 : System.Web.UI.Page
    {
        string host = "ftp://upenergia.edu.mx/SIAUPE/documentos/";
        string user = "web.upenergia.edu.mx";
        string pass = "Sis73+2021";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            
            if (fuDatos.HasFile)
            {
                int peso = fuDatos.PostedFile.ContentLength;
                if (peso < 5357703)
                {
                    //SaveFile(fuDatos.PostedFile);

                    string fileName = "Aqui.zip";
                    string path = "~/documentos/";
                    Directory.CreateDirectory(Server.MapPath(path));

                    Stream fs = fuDatos.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    string filePath = path + fileName;
                    File.WriteAllBytes(Server.MapPath(filePath), bytes);


                    byte[] fileContents=null;

                    using (StreamReader sourceStream = new StreamReader(Server.MapPath(filePath)))
                    {
                        fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                        sourceStream.Close();
                    }

                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host+fileName);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.Credentials = new NetworkCredential(user, pass);
                        request.ContentLength = fileContents.Length;
                        request.UsePassive = true;
                        request.UseBinary = true;
                        request.ServicePoint.ConnectionLimit = fileContents.Length;
                        request.EnableSsl = false;

                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(fileContents, 0, fileContents.Length);
                            requestStream.Close();
                        }
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        UploadStatusLabel.Text += fileName + " uploaded.<br />";
                        response.Close();
                    }
                    catch (WebException ex)
                    {
                        throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
                    }

            }
                else
                    UploadStatusLabel.Text = "El tamaño del archivo sobrepasa los 5 MB permitidos";
            }
            else
            {
                UploadStatusLabel.Text = "You did not specify a file to upload.";
            }
        }




        void SaveFile(HttpPostedFile file)
        {
            String savePath = Server.MapPath("~/Reportes/");

            string fileName = fuDatos.FileName;
            int a = fileName.IndexOf(".");
            string tipo = fileName.Substring(a);
            string name = "0001" + tipo;
            string pathToCheck = savePath + name;
            string tempfileName = "";
            
            if (tipo.Equals(".zip")|| tipo.Equals(".rar"))
            {
                
                    if (System.IO.File.Exists(pathToCheck))
                    {
                        int counter = 2;
                        while (System.IO.File.Exists(pathToCheck))
                        {
                            tempfileName = counter.ToString() + name;
                            pathToCheck = savePath + tempfileName;
                            counter++;
                        }

                        name = tempfileName;
                        UploadStatusLabel.Text = "A file with the same name already exists." + "<br />Your file was saved as " + name;
                    }
                    else
                    {
                        UploadStatusLabel.Text = "Your file was uploaded successfully.";
                    }
                    savePath += name;
                    fuDatos.SaveAs(savePath);
                }
                
            else
            {
                UploadStatusLabel.Text = "El formato no corresponde con el indicado";
            }

        }

        protected void btnDescargas_Click(object sender, EventArgs e)
        {
            string name = "Requisitos de la Convocatoria.rar";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + name);

            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new NetworkCredential(user, pass);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            using (MemoryStream stream = new MemoryStream())
            {
                response.GetResponseStream().CopyTo(stream);
                Response.AddHeader("content-disposition", "attachment;filename=" + name);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
        }
    }
}
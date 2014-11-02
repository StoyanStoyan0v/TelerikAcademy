using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UploadArchive.Database;

namespace UploadArchive
{
    public partial class FileUpload : System.Web.UI.Page
    {
        public void UploadButton_Click(object sender, EventArgs e)
        {
            byte[] fileData = null;
            Stream fileStream = null;
            int length = 0;

            if (FileUploadControl.HasFile)
            {
                if (FileUploadControl.PostedFile.FileName.EndsWith(".zip"))
                {
                    length = FileUploadControl.PostedFile.ContentLength;
                    fileData = new byte[length + 1];
                    fileStream = FileUploadControl.PostedFile.InputStream;
                    fileStream.Read(fileData, 0, length);

                    MemoryStream memStream = new MemoryStream(fileData);

                    var text = this.GetExtractedFileContent(memStream);

                    var context = new FilesContext();
                    context.Files.Add(new UploadArchive.Database.File()
                    {
                        Content = text
                    });
                    context.SaveChanges();

                    this.Content.Text = text;
                }
                else
                {
                    Response.Write("Invalid file format!");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private string GetExtractedFileContent(MemoryStream memStream)
        {
            ZipInputStream compressedBytes = new ZipInputStream(memStream);

            ZipEntry entry = compressedBytes.GetNextEntry();

            byte[] uncompressedBytes = new byte[entry.Size];
            byte[] tempBuffer = new byte[2048];

            MemoryStream tempMemoryStream = new MemoryStream();
            int bytesRead = 0;

            if (uncompressedBytes.Length > 0)
            {
                do
                {
                    bytesRead = compressedBytes.Read(tempBuffer, 0, tempBuffer.Length);

                    tempMemoryStream.Write(tempBuffer, 0, bytesRead);
                }
                while (bytesRead > 0);
            }

            compressedBytes.Close();

            memStream.Close();

            return ASCIIEncoding.ASCII.GetString(tempMemoryStream.ToArray());
        }
    }
}
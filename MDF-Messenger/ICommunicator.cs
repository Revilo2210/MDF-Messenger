using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace MDF_Messenger
{
    public interface ICommunicator
    {
        string Send(string message);
        void Recieve();

        List<string> GetFiles();
    }

    public class Communicator : ICommunicator
    {
        public string Send(string message)
        {
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create($"ftp://{Config.ServerName}/{DateTime.Now}{Guid.NewGuid()}");
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UsePassive = true;

            ftpWebRequest.Credentials = new NetworkCredential(Config.UserName, Config.Password);

            byte[] messageContent = Encoding.UTF8.GetBytes(message);

            using (Stream requestStream = ftpWebRequest.GetRequestStream())
            {
                requestStream.Write(messageContent, 0, messageContent.Length);
            }

            string response;
            using (FtpWebResponse ftpWebResponse = (FtpWebResponse) ftpWebRequest.GetResponse())
            {
                response = ftpWebResponse.StatusDescription;
            }

            return response;
        }

        public void Recieve()
        {
            List<string> Files = this.GetFiles();

            //Relevante Files finden 
            //Relevante Files downloaden

            throw new NotImplementedException();
        }

        public List<string> GetFiles()
        {
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create($"ftp://{Config.ServerName}/{DateTime.Now}{Guid.NewGuid()}");
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.Credentials = new NetworkCredential(Config.UserName, Config.Password);

            List<string> files = new List<string>();
            using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(ftpWebResponse.GetResponseStream()))
                {
                    string line = streamReader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        files.Add(line);
                        line = streamReader.ReadLine();
                    }
                }
            }

            return files;
        }
    }

    public class TestCommunicator : ICommunicator
    {
        public string Send(string message)
        {
            throw new NotImplementedException();
        }

        public void Recieve()
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles()
        {
            throw new NotImplementedException();
        }
    }
}
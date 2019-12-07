using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebProgBackEnd.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DownloadController : ApiController
    {
        [HttpGet]
        [Route("api/DownloadFile")]
        public HttpResponseMessage DownloadFile(string fileName)
        {
            try
            {
                string file = @"C:/Users/Ekaterina/source/repos/WebApi —5 лаба/WebApi/App_Data/" + fileName; 

                if (!string.IsNullOrEmpty(file))
                {

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var fileStream = new FileStream(file, FileMode.Open);
                    response.Content = new StreamContent(fileStream);
                    //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv"); 
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = file;
                    return response;
                    //return ResponseMessage(response); 
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Download/GetFiles")]
        public IEnumerable<string> GetFiles()
        {
            return new System.IO.DirectoryInfo(@"C:/Users/Ekaterina/source/repos/WebApi —5 лаба/WebApi/App_Data/").GetFiles().Select(x => x.Name);
        }
    }
}
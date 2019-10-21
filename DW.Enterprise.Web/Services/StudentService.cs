using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DW.EnterpriseAPI.Entity;
using Newtonsoft.Json;

namespace DW.Enterprise.Web.Services
{
    public class StudentService : IStudentServicecs
    {
        //const string UrlService = "https://UniversityDW.digitalware.com.co/";
        const string UrlService = "https://localhost:44337/";

        public Task<Student> Add(Student model)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<Student> Get(int id)
        {
            using (var client = new HttpClient())
            {
                // recursos 
                client.BaseAddress = new Uri(UrlService);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(
                        "application/json")
                    );
                var url = UrlService + "api/Students/" + id.ToString();
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.GetAsync(url);
                }
                catch (Exception)
                {
                    // Logger
                    throw;
                }

                Student lista = new Student();
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content
                        .ReadAsStringAsync();
                    try
                    {
                        var lis = JsonConvert
                            .DeserializeObject<Student>
                            (result);
                        lista = lis;
                    }
                    catch (Exception)
                    {
                        // Logger
                        throw;
                    }
                }
                return lista;
            };
        }

        public async Task<List<Student>> GetAll()
        {
            using (var client = new HttpClient() )
            {
                // recursos 
                client.BaseAddress = new Uri(UrlService);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(
                        "application/json")
                    );
                var url = UrlService + "api/Students";
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.GetAsync(url);
                }
                catch (Exception)
                {
                    // Logger
                    throw;
                }

                List<Student> lista = new List<Student>();
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content
                        .ReadAsStringAsync();
                    try
                    {
                        var lis = JsonConvert
                            .DeserializeObject<List<Student>>
                            (result);
                        lista = lis;
                    }
                    catch (Exception)
                    {
                        // Logger
                        throw;
                    }
                }
                return lista;
            };
        }

        public Task<List<Student>> StudentList()
        {
            throw new NotImplementedException();
        }

        public Task<Student> Update(Student model)
        {
            throw new NotImplementedException();
        }
    }
}

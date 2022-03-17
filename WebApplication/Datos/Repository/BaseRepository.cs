using Datos.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public string endPoint = "https://localhost:44317/api/";
        static string endPointFinally = null;
        static HttpClient httpClient = new HttpClient();
        public async Task<T> AgregarAsync(T entity)
        {

            try
            {
                StringContent data = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endPointFinally, data);
                response.EnsureSuccessStatusCode();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar Datos:" + ex);
            }


        }

        public async Task<T> EditarAsync(T entity)
        {
            try
            {
                StringContent data = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(endPointFinally, data);
                response.EnsureSuccessStatusCode();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error",ex);
            }
        }

        public async Task<T> EliminarAsync(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            var reponse = await httpClient.DeleteAsync(endPointFinally + "/" + id);
            string apiReponse = await reponse.Content.ReadAsStringAsync();
            if (apiReponse == "")
            {
                return null;

            }
            return null;

        }



        public async Task<IEnumerable<T>> MostrarTodoAsync()
        {
            List<T> lista = new List<T>();

            var reponse = await httpClient.GetAsync(endPointFinally);
            reponse.EnsureSuccessStatusCode();
            string jsonArray = await reponse.Content.ReadAsStringAsync();



            return lista = JsonConvert.DeserializeObject<List<T>>(jsonArray);

        }

        public string ConexionMapper(string value)
        {
            string nombre = $"{endPoint}{value}";
            endPointFinally = nombre;

            return nombre;
        }

        public async Task<IEnumerable<T>> FiltrarAsync()
        {
            try
            {
                List<T> list = new List<T>();
                var response = await httpClient.GetAsync(endPointFinally);
                string apiReponse = await response.Content.ReadAsStringAsync();
                if (apiReponse == "")
                {
                    return null;
                }
                var results = JsonConvert.DeserializeObject<dynamic>(apiReponse);
                JArray array = new JArray();
                array.Add(results);
                string datas = Convert.ToString(array);
                datas = datas.Trim().TrimStart('{').TrimEnd('}');
                return list = JsonConvert.DeserializeObject<List<T>>(datas);
            }

            catch (Exception e)
            {
                throw new Exception("Eror al Filtrar" + e);
            }
        }
    }
}

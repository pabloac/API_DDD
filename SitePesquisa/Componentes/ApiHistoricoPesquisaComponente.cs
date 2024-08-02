using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SitePesquisa.Componentes
{

	public class ApiHistoricoPesquisaComponente
	{
		public string _basePoint = "http://localhost:5095";


        public RSDefault AdicionarHistoricoPesquisa(ResultadoPesquisaRQ requestObj)
        {
            string endPoint = "/api/AdicionarHistoricoPesquisa/";
            string completePoint = _basePoint + endPoint;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, completePoint);
            

            string jsonString = JsonConvert.SerializeObject(requestObj);
            var content = new StringContent(jsonString, null, "application/json");
            request.Content = content;

            var task = Task.Run(() => client.SendAsync(request));
            task.Wait();

            var response = task.Result.Content.ReadAsStringAsync();
            //lblLog.Text = response.Result;
            var responseObj = (RSDefault)JsonConvert.DeserializeObject(response.Result, typeof(RSDefault));

            return responseObj;

        }


        public class RSDefault
        {
            public string status { get; set; }
        }

        public class ResultadoPesquisaRQ
        {
            public string Titulo { get; set; }

            public string Descricao { get; set; }
            public string CargaHoraria { get; set; }
            public string Professor { get; set; }

        }


    }
}
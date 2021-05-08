using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_contabilidad_softland;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace api_contabilidad_softland.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContabilidadController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Request>> PostContabilidad(Request request)
        {
            Response response = new Response();
            response = await Task.Run(() => respuestaContabilidad(request.txtContabilidad));
            return Ok(response);
        }
        public static async Task <Response> respuestaContabilidad(string txtContabilidad)
        {
            Response response = new Response();
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("http://web.softlandcloud.cl/CAPTURATRANSACCIONES/api/VoucherTransaction/GeneraTransaccion?idempresa=438289F9-4263-4817-9DBF-9073D5533A4A&tipo=0&capturasinohayerrores=false&correo=alejandro.zarate@agys.cl"),
                        Content = new StringContent(txtContabilidad, Encoding.UTF8, "application/x-www-form-urlencoded"),
                    };
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "NDk4NDAzRjItRDBEMi00NDFDLUI0NTktREI5MDcyRjQ5M0RCOkQ5NjA0NDBFLUNEMEQtNDkzOC05RjY3LUE3RUQ5N0MzQjQ1Mw==");
                    var responseConta = await client.SendAsync(request);
                    var responseBody = await responseConta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Response>(responseBody);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        } 
    }
}

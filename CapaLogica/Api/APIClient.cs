using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Api
{
	public class APIClient
	{
		private readonly HttpClient httpClient;

		public APIClient()
		{
			// Configurar HttpClient con la base URL de la API (si es necesario)
			httpClient = new HttpClient();
			// httpClient.BaseAddress = new Uri("https://api.example.com/");
		}

		public async Task<string> SendPostRequest(string apiUrl, string postData, string token)
		{
			try
			{
				// Preparar los datos que deseas enviar en la solicitud POST
				var content = new StringContent(postData, Encoding.UTF8, "application/json");
				content.Headers.Add("Authentication", token);
				// Realizar la solicitud POST a la API
				HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

				// Leer la respuesta de la API
				string responseBody = await response.Content.ReadAsStringAsync();

				// Si es necesario, manejar la respuesta aquí antes de devolverla
				return responseBody;
			}
			catch (HttpRequestException ex)
			{
				return $"Error en la solicitud POST: {ex.Message}";
			}
		}

		public async Task<string> SendGetRequest(string apiUrl)
		{
			try
			{
				// Realizar la solicitud GET a la API
				HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

				// Leer la respuesta de la API
				string responseBody = await response.Content.ReadAsStringAsync();

				// Si es necesario, manejar la respuesta aquí antes de devolverla
				return responseBody;
			}
			catch (HttpRequestException ex)
			{
				return $"Error en la solicitud POST: {ex.Message}";
			}
		}
	}
}
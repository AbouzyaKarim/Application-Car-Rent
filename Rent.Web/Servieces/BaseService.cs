using Newtonsoft.Json;
using Rent.Web.Models;
using Rent.Web.Servieces.IService;
using System.Text;

namespace Rent.Web.Servieces
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("RentAPI");
                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(apiRequest.URL);

                client.DefaultRequestHeaders.Clear();
                if (apiRequest.DATA != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.DATA), Encoding.UTF8, "application/json");

                }

               
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.apitype)
                {
                    case SD.APIType.POST: message.Method = HttpMethod.Post; break;
                    case SD.APIType.PUT: message.Method = HttpMethod.Put; break;
                    case SD.APIType.DELETE: message.Method = HttpMethod.Delete; break;
                    default: message.Method = HttpMethod.Get; break;
                }

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTo = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTo;
            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>() { Convert.ToString(e.Message) },
                    isSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;

            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}

using ContractorCore.DBModels;
using ContractorCore.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ContractorCore.Services
{
    public class ApiContractorConsumer : IApiContractorConsumer
    {
        HttpClient httpClient = null;
        private HttpContext currentContext;

        public ApiContractorConsumer(IHttpContextAccessor httpContextAccessor)
        {
            currentContext = httpContextAccessor.HttpContext;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(GetBaseUrl());
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string GetBaseUrl()
        {
            var request = currentContext.Request;
            var host = request.Host.ToUriComponent();
            var pathBase = request.PathBase.ToUriComponent();
            return $"{request.Scheme}://{host}{pathBase}";
        }

        public HttpResponseMessage CreateContractor(oContractor concontractor)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GetBaseUrl() + "/api/Contractor");

            string json = JsonConvert.SerializeObject(concontractor);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient http = new HttpClient();
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        public HttpResponseMessage DeleteContractor(oContractor contractor)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, GetBaseUrl() + "/api/Contractor");

            string json = JsonConvert.SerializeObject(contractor);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient http = new HttpClient();
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        public oContractor GetContractor(int id)
        {
            HttpResponseMessage response = httpClient.GetAsync("/api/Contractor/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var obj = response.ContentAsType<oContractor>();
                return obj;
            }
            return null;
        }

        public IEnumerable<oContractor> GetContractorList()
        {
            HttpResponseMessage response = httpClient.GetAsync("/api/Contractor").Result;
            if (response.IsSuccessStatusCode)
            {
                var obj = response.ContentAsType<List<oContractor>>();
                return obj;
            }
            return null;
        }

        public HttpResponseMessage UpdateContractor(oContractor contractor)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GetBaseUrl() + "/api/Contractor");

            string json = JsonConvert.SerializeObject(contractor);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient http = new HttpClient();
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }
    }
}

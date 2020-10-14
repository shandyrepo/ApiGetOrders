using ApiGetOrders.Models.Authentification;
using ApiGetOrders.Models.Response;
using ApiGetOrders.Sevices.Interfaces;
using System;
using System.Collections;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiGetOrders.Sevices
{
    public class ApiService : IApiService
    {
        private AuthentificationModel _authentificationData;
        public ApiService(AuthentificationModel authentificationData)
        {
            _authentificationData = authentificationData;
            ApiHelper.InitializeClient(_authentificationData.BaseUrl);
        }

        public async Task<IEnumerable> GetOrdersAsync()
        {
            Uri accessTokenUri = new Uri(_authentificationData.BaseUrl + $"orders?oauth_token={_authentificationData.AccessToken}");
            using HttpResponseMessage responseAccess = await ApiHelper.Client.GetAsync(accessTokenUri);
            var orderInfo = await JsonSerializer.DeserializeAsync<OrderResponseInfo>(await responseAccess.Content.ReadAsStreamAsync());
            return orderInfo.Result;
        }

        public async Task<bool> Login()
        {
            RequestTokenData requestTokenInfo = await GetRequestToken();
            if (requestTokenInfo == null || !requestTokenInfo.Success)
                return false;

            AccessTokenData accessTokenInfo = await GetAccessToken(requestTokenInfo.RequestToken);
            if (accessTokenInfo == null || !accessTokenInfo.Success)
                return false;

            _authentificationData.AccessToken = accessTokenInfo.AccessToken;
            _authentificationData.RefreshToken = accessTokenInfo.RefreshToken;

            return true;
        }

        private async Task<AccessTokenData> GetAccessToken(string requestToken)
        {
            string password = ApiHelper.GeneratePassword(_authentificationData, requestToken);
            if (!string.IsNullOrEmpty(password))
            {
                Uri accessTokenUri = new Uri(_authentificationData.BaseUrl + $"oauth/accesstoken?oauth_token={requestToken}&grant_type=api&username={_authentificationData.PublicKey}&password={password}");
                using HttpResponseMessage responseAccess = await ApiHelper.Client.GetAsync(accessTokenUri);
                return await JsonSerializer.DeserializeAsync<AccessTokenData>(await responseAccess.Content.ReadAsStreamAsync());
            }
            return null;
        }
        public async Task<RequestTokenData> GetRequestToken()
        {
            using HttpResponseMessage response = await ApiHelper.Client.GetAsync(new Uri(_authentificationData.BaseUrl + "oauth/requesttoken"));
            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<RequestTokenData>(await response.Content.ReadAsStreamAsync());
            return null;
        }

    }
}

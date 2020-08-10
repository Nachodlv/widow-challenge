using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace PubgAPI
{
    public class PubgHttpClient
    {
        private const string ApiUrl = "https://api.pubg.com/";
        private readonly string _apiKey;

        public delegate void GetCallback(UnityWebRequest request);

        public PubgHttpClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Get(MonoBehaviour monoBehaviour, string url, GetCallback callback)
        {
            monoBehaviour.StartCoroutine(MakeGetRequest(url, callback));
        }

        private IEnumerator MakeGetRequest(string url, GetCallback callback)
        {
            var request = UnityWebRequest.Get($"{ApiUrl}{url}");
            request.SetRequestHeader("Accept", "application/vnd.api+json");
            request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
            yield return request.SendWebRequest();
            callback(request);
        }
    }
}

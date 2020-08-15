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

        /// <summary>
        /// <para>Makes a GET request to https://api.pubg.com/</para>
        /// </summary>
        /// <param name="monoBehaviour">Used to start the coroutine needed to await the get request</param>
        /// <param name="url">Added at the end of https://api.pubg.com/</param>
        /// <param name="callback">Invoked when the request is finished</param>
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

using PubgAPI.Models;
using UnityEngine;

namespace PubgAPI
{
    public class PubgService: MonoBehaviour
    {
        [SerializeField, Tooltip("Name of the json file with the api key")] private string pubgApiKeyJson;

        private const string TournamentUrl = "tournaments";
        private PubgHttpClient _httpClient;

        public delegate void PubgTournamentsCallback(Tournament[] tournaments);
        public delegate void ErrorCallback(string error);

        private void Awake()
        {
            var apiKey = Resources.Load(pubgApiKeyJson) as TextAsset;
            if (apiKey == null)
            {
                Debug.LogError($"No api key found at Assets/Resources/{pubgApiKeyJson}");
                return;
            }

            var pubgApiKey = JsonUtility.FromJson<PubgApiKey>(apiKey.text);
            _httpClient = new PubgHttpClient(pubgApiKey.Key);
        }

        public void GetTournaments(PubgTournamentsCallback callback, ErrorCallback errorCallback)
        {
            _httpClient.Get(this, TournamentUrl, request =>
            {
                if (request.responseCode.Equals(200))
                {
                    callback(JsonUtility.FromJson<TournamentsResponse>(request.downloadHandler.text).Data);
                }
                else
                {
                    errorCallback(request.error);
                }
            });
        }
    }
}

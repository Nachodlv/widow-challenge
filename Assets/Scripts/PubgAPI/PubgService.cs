using System;
using PubgAPI.Models;
using UI;
using UnityEngine;

namespace PubgAPI
{
    public class PubgService : MonoBehaviour
    {
        [SerializeField, Tooltip("Name of the json file with the api key")]
        private string pubgApiKeyJson;

        [SerializeField] private ErrorDisplayer errorDisplayer;

        private const string TournamentUrl = "tournaments";
        private PubgHttpClient _httpClient;

        public delegate void PubgTournamentsCallback(Tournament[] tournaments);

        public delegate void ErrorCallback(string error);

        private void Awake()
        {
            InstantiateHttpClient();
        }

        /// <summary>
        /// <para>Requests all the tournaments from the pubg api from the '/tournaments' endpoint</para>
        /// </summary>
        /// <param name="callback">If the status code is 200 it will invoke this function with the tournaments as argument</param>
        /// <param name="errorCallback">If the status is not 200 it will invoke this function with the requests error as argument</param>
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

        private void InstantiateHttpClient()
        {
            var apiKey = Resources.Load(pubgApiKeyJson) as TextAsset;
            if (apiKey == null)
            {
                var error = $"No api key found at Assets/Resources/{pubgApiKeyJson}";
                errorDisplayer.ShowError(error, 10);
                Debug.LogError(error);
                return;
            }

            var pubgApiKey = JsonUtility.FromJson<PubgApiKey>(apiKey.text);
            _httpClient = new PubgHttpClient(pubgApiKey.Key);
        }
    }
}

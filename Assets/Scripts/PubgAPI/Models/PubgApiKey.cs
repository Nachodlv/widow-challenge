using System;
using UnityEngine;

namespace PubgAPI.Models
{
    [Serializable]
    public class PubgApiKey
    {
        [SerializeField] private string apiKey;
        public string Key => apiKey;
    }
}

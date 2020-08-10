using System;
using UnityEngine;

namespace PubgAPI.Models
{
    [Serializable]
    public class Tournament
    {
        [SerializeField] private string id;
        [SerializeField] private string createdAt;
        public string Id => id;
        public string CreatedAt => createdAt;
    }
}

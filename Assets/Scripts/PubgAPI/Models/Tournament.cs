using System;
using UnityEngine;

namespace PubgAPI.Models
{
    [Serializable]
    public class Tournament
    {
        [SerializeField] private string id;
        [SerializeField] private Attributes attributes;
        public string Id => id;
        public string CreatedAt => attributes.CreatedAt;
    }

    [Serializable]
    public class Attributes
    {
        [SerializeField] private string createdAt;
        public string CreatedAt => createdAt;
    }
}

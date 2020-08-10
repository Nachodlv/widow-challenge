using System;
using UnityEngine;

namespace PubgAPI.Models
{
    [Serializable]
    public class TournamentsResponse
    {
        [SerializeField] private Tournament[] data;
        public Tournament[] Data => data;
    }
}

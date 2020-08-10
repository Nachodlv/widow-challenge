using System;
using PubgAPI;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private PubgService pubgService;

        private void Start()
        {
            pubgService.GetTournaments(tournaments => Debug.Log(tournaments.Length), Debug.LogError);
        }
    }
}

using System;
using PubgAPI;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private PubgService pubgService;
        [SerializeField] private TournamentList tournamentList;

        private void Start()
        {
            pubgService.GetTournaments(tournaments => tournamentList.AddTournaments(tournaments), Debug.LogError);
        }
    }
}

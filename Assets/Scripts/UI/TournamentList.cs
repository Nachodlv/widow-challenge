using System;
using System.Collections.Generic;
using PubgAPI.Models;
using UnityEngine;

namespace UI
{
    public class TournamentList : MonoBehaviour
    {
        [SerializeField] private TournamentUI tournamentUiPrefab;
        [SerializeField] private RectTransform content;

        private List<TournamentUI> _tournamentUiPool;

        private void Awake()
        {
            _tournamentUiPool = new List<TournamentUI>();
        }

        public void AddTournaments(Tournament[] tournaments)
        {
            for (var i = 0; i < tournaments.Length; i++)
            {
                ActivateTournament(tournaments[i],
                    _tournamentUiPool.Count < i ? _tournamentUiPool[0] : CreateNewTournamentUI());
            }

            DeactivateUnused(tournaments);
        }

        private void DeactivateUnused(Tournament[] tournaments)
        {
            for (var i = tournaments.Length; i < _tournamentUiPool.Count; i++)
            {
                _tournamentUiPool[i].gameObject.SetActive(false);
            }
        }

        private void ActivateTournament(Tournament tournament, TournamentUI tournamentUi)
        {
            tournamentUi.Tournament = tournament;
            tournamentUi.gameObject.SetActive(true);
        }

        private TournamentUI CreateNewTournamentUI()
        {
            var tournamentUi = Instantiate(tournamentUiPrefab, content);
            _tournamentUiPool.Add(tournamentUi);
            return tournamentUi;
        }
    }
}

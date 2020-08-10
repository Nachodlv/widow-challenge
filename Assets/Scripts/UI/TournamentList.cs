using System;
using System.Collections.Generic;
using PubgAPI;
using PubgAPI.Models;
using UnityEngine;

namespace UI
{
    public class TournamentList : MonoBehaviour
    {
        [SerializeField] private PubgService pubgService;
        [SerializeField] private TournamentUI tournamentUiPrefab;
        [SerializeField] private RectTransform content;
        [SerializeField] private GameObject loader;
        [SerializeField] private ErrorDisplayer errorDisplayer;

        private List<TournamentUI> _tournamentUiPool;

        private void Awake()
        {
            _tournamentUiPool = new List<TournamentUI>();
        }

        private void Start()
        {
            Reload();
        }

        public void AddTournaments(Tournament[] tournaments)
        {
            for (var i = 0; i < tournaments.Length; i++)
            {
                ActivateTournament(tournaments[i],
                    _tournamentUiPool.Count < i ? _tournamentUiPool[0] : CreateNewTournamentUI());
            }

            DeactivateUnused(tournaments);
            loader.SetActive(false);
        }

        public void Reload()
        {
            loader.SetActive(true);
            pubgService.GetTournaments(AddTournaments, error =>
            {
                errorDisplayer.ShowError(error);
                loader.SetActive(false);
            });
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

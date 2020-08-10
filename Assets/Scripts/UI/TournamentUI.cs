using PubgAPI.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TournamentUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI idText;
        [SerializeField] private TextMeshProUGUI dateText;

        public Tournament Tournament
        {
            set
            {
                idText.text = value.Id;
                dateText.text = value.CreatedAt;
            }
        }
    }
}

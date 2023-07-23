using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Services.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button startButton;

        private IUIService _uiService;

        private void OnEnable()
        {
            startButton.onClick.AddListener(OpenPromo);
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OpenPromo);
        }

        private void OpenPromo()
        {
            _uiService = Container.Locate<IUIService>();
            _uiService.Close("LobbyView");
            _uiService.Show("PromoView");
        }
    }
}
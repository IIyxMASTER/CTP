using Grace.DependencyInjection;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI.Controls;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public class PromoUIControl
    {
        private readonly IExportLocatorScope _container;
        private readonly IUserService _userService;
        private readonly IPromoModel _model;
        private PromoControl _view;
        public PromoUIControl(IPromoModel model, Transform parent, IExportLocatorScope container)
        {
            _container = container;
            _model = model;
            _userService = container.Locate<IUserService>();
            _view = Object.Instantiate(Resources.Load<PromoControl>($"UI/Controls/PromoItem"), parent);
            _view.Init(this,model);
        }

        public void Close()
        {
            Object.Destroy(_view.gameObject);
        }
        public void TryBuy()
        {
            _userService.Buy(_model.Cost);
            
        }
    }
}
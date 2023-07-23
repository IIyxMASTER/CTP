using System.Collections.Generic;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Services.UI;
using UnityEngine;

namespace RedPanda.Project.Services
{
    public class PromoUIService : IPromoUIService
    {
        private Dictionary<IPromoModel, PromoUIControl> _controls = new();
        private readonly IExportLocatorScope _container;

        public PromoUIService(IExportLocatorScope container)
        {
            _container = container;
        }

        public void CreateItem(IPromoModel promoModel, Transform rootsDictionary)
        {
            var viewControl = new PromoUIControl(promoModel, rootsDictionary, _container);
            _controls[promoModel] = viewControl;
        }
    }
}
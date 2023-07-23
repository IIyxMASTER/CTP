using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using RedPanda.Project.Data;
using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoView : View
    {
        [SerializeField] private Transform chestRoot;
        [SerializeField] private Transform inAppRoot;
        [SerializeField] private Transform specialRoot;
        [SerializeField] private TextMeshProUGUI creditsLabel;

        private IPromoService _promoService;
        private IPromoUIService _promoUIService;
        private IUserService _userService;
        private int _lastCurrency;

        private void Start()
        {
            _promoService = Container.Locate<IPromoService>();
            _promoUIService = Container.Locate<IPromoUIService>();
            _userService = Container.Locate<IUserService>();
            var rootsDictionary = new Dictionary<PromoType, Transform>
            {
                { PromoType.Chest, chestRoot },
                { PromoType.Special, specialRoot },
                { PromoType.InApp, inAppRoot }
            };
            var promos = _promoService.GetPromos().OrderByDescending(promo => promo.Rarity);
            foreach (var promoModel in promos)
            {
                _promoUIService.CreateItem(promoModel, rootsDictionary[promoModel.Type]);
            }

            _lastCurrency = _userService.Currency;
            creditsLabel.text = _userService.Currency.ToString();
            _userService.OnCurrencyChanged += () =>
            {
                DOTween.To(() => _lastCurrency, delegate(int value)
                {
                    _lastCurrency = value;
                    creditsLabel.text = value.ToString();
                }, _userService.Currency, 0.1f);
            };
        }
    }
}
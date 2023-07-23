using System;
using DG.Tweening;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services;
using RedPanda.Project.Services.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI.Controls
{
    public class PromoControl : View
    {
        [SerializeField] private Image backGround;
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Button buyButton;

        [Space] [Header("Backgrounds")] [SerializeField]
        private Sprite[] backgroundSprites;

        private PromoUIControl _service;
        private IPromoModel _model;
        private Tweener _tweener;

        private void OnEnable()
        {
            buyButton.onClick.AddListener(TryBuy);
        }

        private void OnDisable()
        {
            buyButton.onClick.RemoveListener(TryBuy);
        }

        private void TryBuy()
        {
            _service.TryBuy();
            _tweener = transform.DOScale(Vector3.one * 1.1f, 0.2f);
            _tweener.SetLoops(2, LoopType.Yoyo);
            _tweener.ChangeStartValue(Vector3.one);
            _tweener.Play();
        }

        public void Init(PromoUIControl service, IPromoModel model)
        {
            _service = service;
            _model = model;
            var sprite = Resources.Load<Sprite>($"Sprites/{model.GetIcon()}");
            if (sprite != null)
            {
                icon.sprite = sprite;
            }

            title.text = model.Title;
            price.text = $"x{model.Cost}";
            backGround.sprite = backgroundSprites[(int)model.Rarity];
        }
    }
}
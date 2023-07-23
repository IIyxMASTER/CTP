using System;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Services
{
    public sealed class UserService : IUserService
    {
        public int Currency { get; private set; }

        public void Buy(int amount)
        {
            if (HasCurrency(amount))
            {
                ReduceCurrency(amount);
            }
            else
            {
                Debug.LogError("You don't have enough gems");
            }
        }

        public Action OnCurrencyChanged { get; set; }

        public UserService()
        {
            Currency = 1000;
        }

        public void AddCurrency(int delta)
        {
            Currency += delta;
            OnCurrencyChanged?.Invoke();
        }

        public void ReduceCurrency(int delta)
        {
            Currency -= delta;
            OnCurrencyChanged?.Invoke();
        }
        
        public bool HasCurrency(int amount)
        {
            return Currency >= amount;
        }
    }
}
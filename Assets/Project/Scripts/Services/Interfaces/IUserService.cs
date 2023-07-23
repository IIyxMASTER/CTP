using System;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUserService
    {
        void AddCurrency(int delta);
        void ReduceCurrency(int delta);
        bool HasCurrency(int amount);
        int Currency { get; }
        void Buy(int amount);
        Action OnCurrencyChanged { get; set; }
    }
}
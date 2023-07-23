using System.Collections.Generic;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IPromoUIService
    {
        void CreateItem(IPromoModel promoModel, Transform rootsDictionary);
    }
}
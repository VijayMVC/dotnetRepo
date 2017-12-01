using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddModelVM
    {
        public CarModel CModel { get; set; }
        public List<SelectListItem> MakeItems { get; set; }

        public AddModelVM()
        {
            CModel = new CarModel();

            MakeItems = new List<SelectListItem>();
        }

        public void SetMakeItems(IEnumerable<Make> makeItems)
        {
            foreach (var item in makeItems)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = item.MakeName,
                    Text = item.MakeName
                });
            }
        }
    }
}
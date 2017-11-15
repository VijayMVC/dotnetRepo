using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class VehicleVM
    {
        public Vehicle AVehicle { get; set; }
        public List<SelectListItem> MakeItems { get; set; }
        public List<SelectListItem> CarModelItems { get; set; }

        public VehicleVM()
        {
            AVehicle = new Vehicle();

            MakeItems = new List<SelectListItem>();
            CarModelItems = new List<SelectListItem>();
        }

        public void SetMakeItems(IEnumerable<Make> makeItems)
        {
            foreach (var item in makeItems)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = item.MakeID.ToString(),
                    Text = item.MakeName
                });
            }
        }

        public void SetCarModelItems(IEnumerable<CarModel> carModelItems)
        {
            foreach (var item in carModelItems)
            {
                CarModelItems.Add(new SelectListItem()
                {
                    Value = item.CarModelID.ToString(),
                    Text = item.ModelName
                });
            }
        }


    }
}
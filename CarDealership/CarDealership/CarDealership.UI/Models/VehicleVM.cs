using CarDealership.Models;
using CarDealership.Models.Tables;
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
        public List<SelectListItem> CarTypeItems { get; set; }
        public List<SelectListItem> BodyTypeItems { get; set; }
        public List<SelectListItem> CarTransmissionItems { get; set; }
        public List<SelectListItem> CarInteriorItems { get; set; }
        public HttpPostedFileBase File { get; set; }

        public VehicleVM()
        {
            AVehicle = new Vehicle();

            MakeItems = new List<SelectListItem>();
            CarModelItems = new List<SelectListItem>();
            CarTypeItems = new List<SelectListItem>();
            BodyTypeItems = new List<SelectListItem>();
            CarTransmissionItems = new List<SelectListItem>();
            CarInteriorItems = new List<SelectListItem>();
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

        internal void SetCarInteriorItems()
        {
            CarInteriorItems.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Brown Leather"
            });

            CarInteriorItems.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Black Leather"
            });

            CarInteriorItems.Add(new SelectListItem()
            {
                Value = "3",
                Text = "White Leather"
            });

            CarInteriorItems.Add(new SelectListItem()
            {
                Value = "4",
                Text = "Black Cloth Upholstry"
            });

            CarInteriorItems.Add(new SelectListItem()
            {
                Value = "5",
                Text = "White Cloth Upholstry"
            });
        }

        internal void SetCarTransmissionItems()
        {
            CarTransmissionItems.Add(new SelectListItem()
            {
                Value = "true",
                Text = "Automatic"
            });

            CarTransmissionItems.Add(new SelectListItem()
            {
                Value = "false",
                Text = "Manual"
            });
        }

        internal void SetBodyTypeItems(IEnumerable<BodyType> bodyTypeItems)
        {
            foreach (var item in bodyTypeItems)
            {
                BodyTypeItems.Add(new SelectListItem()
                {
                    Value = item.BodyTypeID.ToString(),
                    Text = item.BodyTypeName
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

        public void SetCarTypeItems()
        {
                CarTypeItems.Add(new SelectListItem()
                {
                    Value = "true",
                    Text = "New"
                });

                CarTypeItems.Add(new SelectListItem()
                {
                    Value = "false",
                    Text = "Used"
                });
        }
    }
}
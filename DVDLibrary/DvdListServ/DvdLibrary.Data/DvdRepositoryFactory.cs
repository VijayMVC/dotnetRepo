using DvdLibrary.Data.ADO;
using DvdLibrary.Data.EF;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                case "EF":
                    return new DvdRepositoryEF();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}

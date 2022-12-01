using Microsoft.AspNetCore.Mvc;
using ORozdobudko;
using Web_cross_platform.Models;

namespace Web_cross_platform.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult PR1()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult PR1(CommonDataModel commonDataModel)
        {
            try
            {
                commonDataModel.Response = (Lab_1.Algoritm(Int32.Parse(commonDataModel.Data))).ToString();
                commonDataModel.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                commonDataModel.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                commonDataModel.ErrorValue = ex.Message;
            }
            return View(commonDataModel);
        }

        public IActionResult PR2()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult PR2(CommonDataModel commonDataModel)
        {
            try
            {
                commonDataModel.Response = (Lab_2.Algoritm(Int32.Parse(commonDataModel.Data))).ToString();
                commonDataModel.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                commonDataModel.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                commonDataModel.ErrorValue = ex.Message;
            }
            return View(commonDataModel);
        }

        public IActionResult PR3()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult PR3(CommonDataModel commonDataModel)
        {
            try
            {
                Lab_3 lab_3 = new Lab_3();
                lab_3.Algoritm(commonDataModel.Data);
                commonDataModel.Response = lab_3.Cycle == 0 ? "YES" : "NO";
                commonDataModel.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                commonDataModel.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                commonDataModel.ErrorValue = ex.Message;
            }
            return View(commonDataModel);
        }
    }
}

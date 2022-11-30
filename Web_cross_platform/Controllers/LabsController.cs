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
        public IActionResult PR2(CommonDataModel triangleModel)
        {
            try
            {
                triangleModel.Response = (Lab_2.Algoritm(Int32.Parse(triangleModel.Data))).ToString();
                triangleModel.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                triangleModel.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                triangleModel.ErrorValue = ex.Message;
            }
            return View(triangleModel);
        }
    }
}

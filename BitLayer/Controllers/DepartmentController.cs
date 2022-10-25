using Bitlayer.Bll.Services;
using BitLayer.Domain.Models;
using dataTable.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BitLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _department;

        public DepartmentController(IDepartmentService department)
        {
            _department = department;
        }


        public IActionResult Index()
        {
            return View();   
        }

        [HttpPost]
        public JsonResult GetAllDepartment()
        {

            var request = new DataTableRequest();

            request.Draw = Convert.ToInt32(Request.Form["draw"].FirstOrDefault());
            request.Start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            request.Length = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            request.Search = new DataTableSearch()
            {
                Value = Request.Form["search[value]"].FirstOrDefault()
            };
            request.Order = new DataTableOrder[] {
            new DataTableOrder()
            {
                Dir = Request.Form["order[0][dir]"].FirstOrDefault(),
                Column = Convert.ToInt32(Request.Form["order[0][column]"].FirstOrDefault())
            }};

            return Json(_department.GetDepartmentAsync(request).Result);

        }




        [HttpPost]
        public IActionResult Add(Department department)
        {
           
                _department.AddDepartment(department);

            return View();



        }

        [HttpPost]
        public IActionResult Edit(int Id,Department department)
        {

            _department.EditDepartment(Id ,department);
            return Json(new { success = true, message = "Update Successfully" });



        }


        [HttpPost]
        public IActionResult detail(int Id)
        {

            var dep =  _department.GetDepartmentById(Id);
            return View(dep);



        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {

            _department.DeleteDep(Id);
            return Json(new { success = true, message = "Delete Successfully" });



        }
    }
}

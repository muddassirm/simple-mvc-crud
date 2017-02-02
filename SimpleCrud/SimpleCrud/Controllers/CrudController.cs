using SimpleCrud.Models;
using SimpleCrud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class CrudController : Controller
    {
        PatientRepository _repository;

        public CrudController()
        {
            _repository = new PatientRepository();
        }

        //
        // GET: /Crud/
        public ActionResult Index()
        {
            return View("CrudView");
        }

        public JsonResult GetAllRecords()
        {
            return Json(new { Result = "OK", Records = _repository.GetAllRecords() });
        }

        public JsonResult Update(Patient patient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                _repository.Update(patient);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Insert(Patient patient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                patient.Id = _repository.Insert(patient);

                return Json(new { Result = "OK", Record = patient });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public JsonResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_CRUD_Demo.Models;

namespace Web_CRUD_Demo.Controllers {
  public class HomeController : Controller {
    public ActionResult Index() {
      return View(model: new Model_EmployeeNumber().GetEmployeeNumber());
    }
    public ActionResult Add() {
      var currentState = "";
      if (!string.IsNullOrEmpty(Request["txtNumber"]) || !string.IsNullOrEmpty(Request["txtName"])) {
        if (new Model_EmployeeNumber().InsertEmployeeNumber(int.Parse(Request["txtNumber"]), Request["txtName"]) == 1) {
          currentState = "1";
        } else {
          currentState = "0";
        }
      }
      return View(model: currentState);
    }
    public ActionResult Update() {
      if (!string.IsNullOrEmpty(Request["txtNumber"]) && !string.IsNullOrEmpty(Request["txtName"])) {
        if (new Model_EmployeeNumber().UpdateEmployeeNumber(number: int.Parse(Request["txtNumber"]), name: Request["txtName"]) == 1) {
          return RedirectToAction("Index");
        }
      }
      return View(model: new Model_EmployeeNumber().GetEmployeeNumber(int.Parse(Request["RowNumber"])).AsEnumerable().FirstOrDefault());
    }
    public string Delete() {
      return new Model_EmployeeNumber().DeteleEmployeeNumber(int.Parse(Request["number"])).ToString();
    }
  }
}
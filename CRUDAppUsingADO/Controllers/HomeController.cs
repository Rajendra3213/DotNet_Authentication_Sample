using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDAppUsingADO.Models;

namespace CRUDAppUsingADO.Controllers;

public class HomeController : Controller
{
    private readonly EmployeeDataAccessLayer dal;

    public HomeController()
    {
        dal = new EmployeeDataAccessLayer();
    }

    public IActionResult Index()
    {
        List<Employees> emps = dal.GetAllEmployees();
        return View(emps);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employees emp)
    {
        try
        {
            dal.AddEmployee(emp);
            return RedirectToAction("Index");

        }
        catch
        {
            return View();
        }

    }

    public IActionResult Edit(int id)
    {
        Employees emp = dal.getEmployeesById(id);
        return View(emp);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Employees emp)
    {
        try
        {
            dal.UpdateEmployeeById(emp);
            return RedirectToAction("Index");

        }
        catch
        {
            return View();
        }

    }

    public IActionResult Details(int id)
    {
        Employees emp = dal.getEmployeesById(id);
        return View(emp);
    }

    public IActionResult Delete(int id)
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Employees employees)
    {
        dal.DeleteRecord(employees.Id);
        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

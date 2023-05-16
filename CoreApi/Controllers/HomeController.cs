using BusinessLayer.InterfacesOfManagers;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers;

[ApiController]
[Route("h")]
public class HomeController : Controller
{
    private readonly IStudentManager _manager;

    public HomeController(IStudentManager manager)
    {
        _manager = manager;
    }


    [HttpGet]
    [Route("alls")]
    [Authorize] //giris yapmadan bu metoda ulasamayacagiz.
    public IActionResult AllStudents()
    {
        try
        {
            var data = _manager.GetAll();
            return Ok(data);
        }
        catch (Exception e)
        {
            return Problem(e.Message);

        }
    }
    
    [HttpPost]
    [Route("[action]")]
    public IActionResult AddStudent(StudentVM model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Problem("Bilgileri Eksiksiz girdiginize emin olun Tekrar Deneyiniz ! ");
                
            }
            
            

            int index = model.Name.IndexOf(' ');
            model.FirstName = model.Name;
            if (index > -1)
            {
                model.FirstName = model.Name.Substring(0, index);
                model.SecondName = model.Name.Substring(index);
            }
           

            var result =   _manager.Add(model);

          return Created("",result.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);

        }
    }
    
    [HttpGet]
    [Route("find")]
    public IActionResult FindStudentsByYear(int? year)
    {
        try
        {
            if (year == null)
            {
                //yil degeri verilmedi ise butun ogrencileri gondersin.
                return Problem("Yıl degeri vermediniz..");
            }

            var result = _manager.GetAll(
                x => x.BirthDate != null && x.BirthDate.Value.Year == year).Data;

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return Problem("Uygun veri bulunamadi");
            }
            
        }
        catch (Exception e)
        {
            return Problem(e.Message);

        }
    }
}
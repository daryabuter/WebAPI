using Microsoft.AspNetCore.Mvc;
using Project.Data.Interfaces;

public class AccountController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet] //oбработчик для GET-запроса на страницу авторизации
    public IActionResult Login()
    {
        return View(); //в озвращаем представление для страницы авторизации
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _authenticationService.Authenticate(username, password);
        if (user == null)
        {
            //пользователь не найден, обработка ошибки
            return View("LoginFailed"); 
        }

        // Выполнение входа пользователя
        return RedirectToAction("List", "Products"); //перенаправление на Products/List
    }
       
}



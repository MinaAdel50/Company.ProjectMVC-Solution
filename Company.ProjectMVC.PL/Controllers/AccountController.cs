using Company.DAL.Models;
using Company.ProjectMVC.PL.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.ProjectMVC.PL.Controllers
{
	public class AccountController(UserManager<ApplicationUser> userManager) : Controller
	{

		private readonly UserManager<ApplicationUser> userManager;
		private UserManager<ApplicationUser> _userManager = userManager;

		[HttpGet]
		public IActionResult signUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> signUp(SignUpViewmModel model)
		{

			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.UserName);
				if (user is null)
				{
					user = await _userManager.FindByEmailAsync(model.Email);
					if (user is null)
					{
						user = new ApplicationUser()
						{
							UserName = model.UserName,
							FirstName = model.FirstName,
							LastName = model.LastName,
							Email = model.Email,
							IsAgree = model.IsAgree,

						};

						var result = await _userManager.CreateAsync(user, model.Password);
						if (result.Succeeded)
						{
							return RedirectToAction("SignIn");
						}
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);

						}

					}
					ModelState.AddModelError(string.Empty, "Email is already exist!!");
					return View(model);

				}

				ModelState.AddModelError(string.Empty, "UserName is already exist!!");
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View(); 
		}

		[HttpPost]
		public  async Task <IActionResult> SignIn(SignInViewModel model)
		{
			if(ModelState.IsValid)
			{
			var user = await _userManager.FindByEmailAsync(model.Email);
				if(user is not null)
				{
				var flag = await _userManager.CheckPasswordAsync(user, model.Password);
					if(flag)
					{
						return RedirectToAction("Index", "Home");
					}



				}
				ModelState.AddModelError(string.Empty, "Invalid Login !!");
			}
			return View(model);

		}



	}
}

﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ENTITY.Concrete;
using Project.UI.Models;

namespace Project.UI.ViewComponents.SideBar
{
    public class SideBar : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public SideBar(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureURL = values.ImageURL;

            return View(model);
        }
    }
}


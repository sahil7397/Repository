using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using PagedList;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Controllers
{
    public class UserController : Controller
    {
        private readonly iUser userRespository;

        public UserController(iUser userRespository)
        {
            this.userRespository = userRespository;
        }
        public async Task<IActionResult> GetUsersList()
        {
            var data = await userRespository.Getusers();
            return View(data);
        }

        public async Task<IActionResult> AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
               await userRespository.AddUser(user);
                if (user.UserId == 0)
                {
                    TempData["UserError"] = "Record Not Saved";
                }
                else
                {
                    TempData["UserSuccess"] = "Record Saved Successfully";
                }
            }
            return RedirectToAction("GetUsersList");
        }
        public async Task<IActionResult>Edit(int id)
        {
            User user =new User();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await userRespository.GetUserById(id);
                    if (user == null)
                    {
                        return NotFound("User Not Found");
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(user);
        }
        [HttpPost]
        public async Task <IActionResult>Edit(User user)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    bool status = await userRespository.UpdateRecord(user);
                    if (status)
                    {
                        TempData["UserUpdateSuccess"] = "User Successfully Update";
                    }
                    else
                    {
                        TempData["UserUpdateError"] = "User Record Not Found";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUsersList");
        }
        public async Task<IActionResult> DeleteRecord(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    bool status = await userRespository.DeleteUser(id);
                    if (status)
                    {
                        TempData["UserDeleted"] = "Record Has Been Successfully Deleted";
                    }
                    else
                    {
                        TempData["UserSuccess"] = "Record Not Deleted";
                    }
                }
              
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUsersList");

        }
    }
}

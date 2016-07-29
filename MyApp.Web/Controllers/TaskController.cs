using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System.Web.Mvc;
using MyApp.ApplicationService;

namespace MyApp.Web.Controllers
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            var result = _taskService.GetTasks();
            
            return View(result);
        }

        public ActionResult Detail(Guid id)
        {
            var result = _taskService.GetTaskDetail(id);

            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string title)
        {
            _taskService.CreateNewTask(Guid.NewGuid(), title);

            return RedirectToAction("Index");
        }


        public ActionResult DecreasePriority(Guid id)
        {
            _taskService.DecreasePriority(id);
            return RedirectToAction("Index");
        }

        public ActionResult IncreasePriority(Guid id)
        {
            _taskService.IncreatePriority(id);
            return RedirectToAction("Index");
        }

        public ActionResult Complete(Guid id)
        {
            _taskService.Complete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            _taskService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
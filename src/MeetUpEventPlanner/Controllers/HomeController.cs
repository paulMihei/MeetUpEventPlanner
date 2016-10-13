using MeetUpEventPlanner.Entities;
using MeetUpEventPlanner.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetUpEventPlanner.ViewModels
{
    [Authorize]
    public class HomeController : Controller
    {
        private IMeetUpEventData _meetUpEventData;

        public HomeController(IMeetUpEventData meetUpEventData)
        {
            _meetUpEventData = meetUpEventData;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.MeetUpEvents = _meetUpEventData.GetAllEvents();

            return View(model);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MeetUpEventEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var meetUpEvent = new MeetUpEvent();
                meetUpEvent.GuestList = model.GuestList;
                meetUpEvent.Host = model.Host;
                meetUpEvent.Location = model.Location;
                meetUpEvent.Message = model.Message;
                meetUpEvent.Name = model.Name;
                meetUpEvent.StartDateAndTime = model.StartDateAndTime;
                meetUpEvent.EndDateAndTime = model.EndDateAndTime;
                meetUpEvent.Type = model.Type;

                _meetUpEventData.Add(meetUpEvent);
                _meetUpEventData.Commit();

                return RedirectToAction("Details", new { id = meetUpEvent.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MeetUpEvent meetUpeEvent = _meetUpEventData.GetEvent(id);
            var model = new MeetUpEventEditViewModel(meetUpeEvent);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, MeetUpEventEditViewModel input)
        {
            var meetUpEvent = _meetUpEventData.GetEvent(id);
            if (ModelState.IsValid)
            {
                meetUpEvent.GuestList = input.GuestList;
                meetUpEvent.Host = input.Host;
                meetUpEvent.Location = input.Location;
                meetUpEvent.Message = input.Message;
                meetUpEvent.Name = input.Name;
                meetUpEvent.StartDateAndTime = input.StartDateAndTime;
                meetUpEvent.EndDateAndTime = input.EndDateAndTime;
                meetUpEvent.Type = input.Type;

                _meetUpEventData.Commit();

                return RedirectToAction("Details", new { id = meetUpEvent.Id });
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _meetUpEventData.GetEvent(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}

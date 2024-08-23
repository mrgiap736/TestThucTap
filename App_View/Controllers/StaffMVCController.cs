using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_Data.Data;
using App_Data.Entities;
using Newtonsoft.Json;
using App_DTO.DataTransferObject;
using App_View.Services;
using App_View.Models;

namespace App_View.Controllers
{
    public class StaffMVCController : Controller
    {
        private readonly HttpClient _client;
        private readonly Staff_MajorServices _services;
        private readonly AppDbContext _context;

        public StaffMVCController(HttpClient client, Staff_MajorServices services, AppDbContext context)
        {
            _client = client;
            _services = services;
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetStringAsync(@"https://localhost:7169/api/Staff/get-all-staff");

            var lst = JsonConvert.DeserializeObject<List<Staff>>(response);

            return View(lst);
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string requestUrl = $"https://localhost:7169/api/Staff/get-staff-by-id?id={id}";
            var response = await _client.GetStringAsync(requestUrl);

            var staff = JsonConvert.DeserializeObject<Staff>(response);

            if (staff == null)
            {
                return NotFound();
            }

            var lstMajor = await _services.GetAllStaffMajor(id);

            ViewBag.ListMajor = lstMajor;

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Code,AccountFE,AccountFPT,Status")] StaffDTO input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string requestUrl = @"https://localhost:7169/api/Staff/create-staff";
                    var response = await _client.PostAsJsonAsync(requestUrl, input);


                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                // Kiểm tra xem ngoại lệ có phải do vi phạm ràng buộc độc nhất không
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Cannot insert duplicate key"))
                {
                    if (ex.InnerException.Message.Contains("AccountFE"))
                    {
                        ModelState.AddModelError("AccountFE", "AccountFE này đã tồn tại. Vui lòng chọn một AccountFE khác.");
                    }
                    if (ex.InnerException.Message.Contains("AccountFPT"))
                    {
                        ModelState.AddModelError("AccountFPT", "AccountFPT này đã tồn tại. Vui lòng chọn một AccountFPT khác.");
                    }
                    if (ex.InnerException.Message.Contains("Code"))
                    {
                        ModelState.AddModelError("Code", "Code này đã tồn tại. Vui lòng chọn một Code khác.");
                    }
                }
            }
                return View(input);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string requestUrl = $"https://localhost:7169/api/Staff/get-staff-by-id?id={id}";
            var response = await _client.GetStringAsync(requestUrl);

            var staff = JsonConvert.DeserializeObject<Staff>(response);

            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Code,AccountFE,AccountFPT")] StaffUpdateRequest input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string requestUrl = "https://localhost:7169/api/Staff/update-staff";

                    await _client.PutAsJsonAsync(requestUrl, input);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> ChangeStatus(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string requestUrl = $"https://localhost:7169/api/Staff/get-staff-by-id?id={id}";
            var response = await _client.GetStringAsync(requestUrl);

            var staff = JsonConvert.DeserializeObject<Staff>(response);

           
            if (staff == null)
            {
                return NotFound();
            }

            if (staff.Status == 0)
            {
                staff.Status = 1;
            }
            else if (staff.Status == 1)
            {
                staff.Status = 0;
            }


            string requestUrl2 = "https://localhost:7169/api/Staff/update-staff";

            await _client.PutAsJsonAsync(requestUrl2, staff);

            return RedirectToAction(nameof(Index));
        }

        //
        [HttpGet]
        public async Task<IActionResult> AddMajor(Guid? id)
        {
            var model = new AddMajorViewModel
            {
                Facilities = await _context.Facility.ToListAsync(),
            };

            model.StaffId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMajor(AddMajorViewModel model)
        {
            if (ModelState.IsValid)
            {
                //logic thêm Major
                var mf = _context.Major_Facility.FirstOrDefault(x => x.MajorId == model.SelectedMajorId);

                var sm = new Staff_MajorFacility();

                sm.Id = Guid.NewGuid();
                sm.StaffId = model.StaffId.Value;
                sm.major_FacilityId = mf.Id;

                _context.Staff_Major.Add(sm);
                await _context.SaveChangesAsync();  

                return RedirectToAction(nameof(Details));
            }

            model.Facilities = _context.Facility.ToList();

            if (model.SelectedFacilityId.HasValue)
            {
                model.Departments = _context.Department
                    .Where(d => d.Department_Facilities.Any(fd => fd.FacilityId == model.SelectedFacilityId.Value))
                    .ToList();
            }

            if (model.SelectedDepartmentId.HasValue)
            {
                model.Majors = _context.Major
                    .Where(m => m.Major_Facilities.Any(mf => mf.department_Facility.DepartmentId == model.SelectedDepartmentId.Value))
                    .ToList();
            }

            return View(model);
        }

        [HttpGet]
        public JsonResult GetDepartments(Guid facilityId)
        {
            var departments = _context.Department
                .Where(d => d.Department_Facilities.Any(fd => fd.FacilityId == facilityId))
                .Select(d => new { d.Id, d.Name })
                .ToList();

            return Json(departments);
        }

        [HttpGet]
        public JsonResult GetMajors(Guid departmentId)
        {
            var majors = _context.Major
                .Where(m => m.Major_Facilities.Any(mf => mf.department_Facility.DepartmentId == departmentId))
                .Select(m => new { m.Id, m.Name })
                .ToList();

            return Json(majors);
        }


        //private bool StaffExists(Guid id)
        //{
        //    return _context.Staff.Any(e => e.Id == id);
        //}
    }
}

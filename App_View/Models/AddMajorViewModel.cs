using App_Data.Entities;

namespace App_View.Models
{
    public class AddMajorViewModel
    {
        public Guid? SelectedFacilityId { get; set; }
        public Guid? SelectedDepartmentId { get; set; }
        public Guid? SelectedMajorId { get; set; }
        public Guid? StaffId { get; set; }

        public List<Facility> Facilities { get; set; }
        public List<Department> Departments { get; set; }
        public List<Major> Majors { get; set; }

        public AddMajorViewModel()
        {
            Facilities = new List<Facility>();
            Departments = new List<Department>();
            Majors = new List<Major>();
        }
    }
}

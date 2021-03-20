using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var attendeeId = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a => a.AttendeeId == attendeeId && a.GigId == dto.GigId);

            if(exists)
            {
                return BadRequest("The Attendance already exist.");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = attendeeId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}

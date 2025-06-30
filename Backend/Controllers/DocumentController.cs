using Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/document")]
    [ApiController]
    
    public class DocumentController : ControllerBase
    {
        private readonly AgreementDbContext _context;
        public DocumentController(AgreementDbContext context) { 
            _context = context;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public IActionResult UploadDocument([FromForm] IFormFile file)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

                if (file == null || file.Length == 0 || string.IsNullOrEmpty(file.ContentType))
                    return BadRequest(new { message = "Invalid file upload." });

                var allowedContentTypes = new[] { "image/jpeg", "image/png", "application/pdf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
                if (!allowedContentTypes.Contains(file.ContentType))
                    return BadRequest(new { message = "Unsupported file type. Please upload JPG, PNG, PDF, or Word documents." });

                if (file.Length > 10485760) // 10 MB limit
                    return BadRequest(new { message = "File size exceeds 10 MB limit." });

                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                var document = new Document
                {
                    Title = file.FileName,
                    Documents = memoryStream.ToArray(),
                    CreatedDate = DateTime.Now,
                    UserId = userId
                };

                _context.Documents.Add(document);
                _context.SaveChanges();

                return Ok(new { id = document.DocumentId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading document: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, new { message = "Internal server error. Please try again later.", error = ex.Message });
            }

        }
    }
}

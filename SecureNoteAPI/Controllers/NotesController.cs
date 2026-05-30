using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureNoteAPI.Data;
using SecureNoteAPI.DTOs;
using SecureNoteAPI.Models;
using System.Security.Claims;

namespace SecureNoteAPI.Controllers
{
    [Route("api/notes")]
    [ApiController]
    [Authorize] 
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        
        private int GetCurrentUserId()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(userIdString!);
        }

        
        [HttpPost]
        public IActionResult AddNote(NoteDto request)
        {
            var userId = GetCurrentUserId();

            var newNote = new Note
            {
                Title = request.Title,
                Content = request.Content,
                UserId = userId
            };

            _context.Notes.Add(newNote);
            _context.SaveChanges();

            
            return Ok(new
            {
                message = "Note added successfully.",
                noteId = newNote.Id
            });
        }

        
        [HttpGet]
        public IActionResult GetNotes()
        {
            var userId = GetCurrentUserId();

            
            var notes = _context.Notes.Where(n => n.UserId == userId).ToList();

            return Ok(notes);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, NoteDto request)
        {
            var userId = GetCurrentUserId();

            
            var note = _context.Notes.FirstOrDefault(n => n.Id == id && n.UserId == userId);

            if (note == null)
            {
                return NotFound("Note not found or you do not have permission to edit it.");
            }

            note.Title = request.Title;
            note.Content = request.Content;

            _context.SaveChanges();

            return Ok(new { message = "Note updated successfully." });
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var userId = GetCurrentUserId();

            
            var note = _context.Notes.FirstOrDefault(n => n.Id == id && n.UserId == userId);

            if (note == null)
            {
                return NotFound("Note not found or you do not have permission to delete it.");
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return Ok(new { message = "Note deleted successfully." });
        }
    }
}
using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class NotesComponentViewModel
    {
        public List<Note> PreviousNotes { get; set; }
        public int SelectedNoteId { get; set; }
        public string InputPerson { get; set; }
        public DateTime NoteDate { get; set; }
        public string NoteDescription { get; set; }

        public NotesComponentViewModel()
        {
            PreviousNotes = new List<Note>();
            NoteDate = DateTime.Now;
        }
    }
}

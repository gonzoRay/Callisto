using System.Collections.Generic;
using System.Linq;
using Callisto.Data.DbModels;

namespace Callisto.Data.Repositories
{
    public class ReleaseNoteRepository : BaseRepository<ReleaseNoteContext>, IReleaseNoteRepository
    {
        public ReleaseNoteRepository(ReleaseNoteContext context)
            : base(context)
        { }

        public IEnumerable<Note> GetAllReleaseNotes()
        {
            var releaseNotes = (from n in Context.Notes
                select n).AsEnumerable();
            return releaseNotes;
        }

        public IEnumerable<Note> SearchRelease(string searchText)
        {
            var searchResults = (from n in Context.Notes
                where n.NoteText.Detail.Contains(searchText)
                select n).AsEnumerable();

                return searchResults;
            }

        public void Add(Note note)
        {
            Context.Notes.Add(note);
            Context.SaveChanges();
        }

        public void Remove(Note note)
        {
            Context.Notes.Remove(note);
            Context.SaveChanges();
        }
    }
}

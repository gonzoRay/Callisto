using System.Collections.Generic;
using Callisto.Data.DbModels;

namespace Callisto.Data.Repositories
{
    public interface IReleaseNoteRepository
    {
        IEnumerable<Note> GetAllReleaseNotes();
        IEnumerable<Note> SearchRelease(string searchText);
        void Add(Note note);
        void Remove(Note note);
    }
}

using System.Collections.Generic;
using Callisto.Domain.Entities;

namespace Callisto.Domain.Services
{
    public interface IReleaseNoteService
    {
        IEnumerable<Note> GetAllReleaseNotes();
        IEnumerable<Note> SearchRelease(string searchText);
        void Add(Note note);
        void Remove(Note note);
    }

}

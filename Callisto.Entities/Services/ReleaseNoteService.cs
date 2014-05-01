using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Callisto.Data;
using Callisto.Domain.Entities;
using Callisto.Data.Repositories;

namespace Callisto.Domain.Services
{
    public class ReleaseNoteService : IReleaseNoteService
    {
        private IReleaseNoteRepository releaseNoteRepository;

        public void GetAllReleaseNotes(IReleaseNoteRepository releaseNoteRepository)
        {
            if(releaseNoteRepository == null)
                throw new ArgumentNullException("releaseNoteRepository");

            this.releaseNoteRepository = releaseNoteRepository;
        }

        public IEnumerable<Note> GetAllReleaseNotes()
        {
            var dbNotes = releaseNoteRepository.GetAllReleaseNotes();
            return dbNotes.Select(n => n.FromDataModel());
        }

        public IEnumerable<Note> SearchRelease(string searchText)
        {
            throw new NotImplementedException();
        }

        public void Add(Note note)
        {
            throw new NotImplementedException();
        }

        public void Remove(Note note)
        {
            throw new NotImplementedException();
        }
    }
}

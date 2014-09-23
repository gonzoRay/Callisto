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
        private IReleaseNoteRepository _releaseNoteRepository;

        public ReleaseNoteService()
        {
            _releaseNoteRepository = new ReleaseNoteRepository(new ReleaseNoteContext("ReleaseNoteContext"));
        }

        public ReleaseNoteService(IReleaseNoteRepository releaseNoteRepository)
        {
            if(releaseNoteRepository == null)
                throw new ArgumentNullException("releaseNoteRepository");

            //HACK: Until DI starts working
            _releaseNoteRepository = new ReleaseNoteRepository(new ReleaseNoteContext("ReleaseNoteContext"));
            //this._releaseNoteRepository = releaseNoteRepository;
        }

        public IEnumerable<Note> GetAllReleaseNotes()
        {
            var dbNotes = _releaseNoteRepository.GetAllReleaseNotes();
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

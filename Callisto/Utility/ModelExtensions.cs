using Callisto.Domain.Entities;

namespace Callisto.Web.Models
{
    public static class ModelExtensions
    {
        public static ReleaseNoteModel FromDomainModel(this Note note)
        {
            return null;
            //return new ReleaseNoteModel
            //{
            //    Id = note.Id,
            //    NoteText = note.NoteText.Detail,
            //};
        }
    }
}
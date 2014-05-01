using DbModels = Callisto.Data.DbModels;

namespace Callisto.Domain.Entities
{
    public static class EntityExtensions
    {
        public static Note FromDataModel(this DbModels.Note note)
        {
            return new Note
            {
                Id = note.Id,
                NoteText = new NoteText
                {
                    Client = note.NoteText.Client,
                    Detail = note.NoteText.Detail,
                    Id = note.NoteTextId,
                    Summary = note.NoteText.Summary,
                }
            };
        }
    }
}
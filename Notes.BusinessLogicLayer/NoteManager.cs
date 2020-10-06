using Notes.DataAccessLayer.Concrete;
using Notes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BusinessLogicLayer
{
    public class NoteManager
    {
        private Repository<Note> repo_note = new Repository<Note>();
        public List<Note> GetListNote()
        {
            List<Note> noteList = repo_note.GetList();
            return noteList;
        }
    }
}

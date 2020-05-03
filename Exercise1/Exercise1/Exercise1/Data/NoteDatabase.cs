using Exercise1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _databaseConnection;
        public NoteDatabase(string dbPath)
        {
            _databaseConnection = new SQLiteAsyncConnection(dbPath);
            _databaseConnection.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _databaseConnection.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _databaseConnection.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if(note.ID != 0)
            {
                return _databaseConnection.UpdateAsync(note);
            }
            else
            {
                return _databaseConnection.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _databaseConnection.DeleteAsync(note);
        }

    }
}

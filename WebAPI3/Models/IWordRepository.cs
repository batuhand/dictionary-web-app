using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI3.Models
{
    public interface IWordRepository
    {
        IEnumerable<WordList> GetAllItems();
        WordList GetItemById(int itemId);

        List<WordList> GetWordByTr(string tr);

        WordList Add(WordList newItem);
        WordList Update(WordList updatedItem);
        void Delete(int id);
        int Commit();

    }
}

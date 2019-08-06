using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI3.Models
{
    public class WordRepository : IWordRepository
    {
        private readonly wordContext _appDbContext;

        public WordRepository(wordContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public WordList Add(WordList newItem)
        {
            _appDbContext.Add(newItem);

            return newItem;
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var item = GetItemById(id);
            if (item != null)
                _appDbContext.WordsList.Remove(item);
        }

        public IEnumerable<WordList> GetAllItems()
        {
            return _appDbContext.WordsList;
        }

        public WordList GetItemById(int itemId)
        {
            return _appDbContext.WordsList.FirstOrDefault(p => p.Id == itemId);
        }

        public List<WordList> GetWordByTr(string tr)
        {
            List<WordList> words = new List<WordList>();
            WordList word = _appDbContext.WordsList.FirstOrDefault(cus => cus.WordTr == tr);
            if (word != null)
            {
                words.Add(word);
            }
            return words;

        }


        public WordList Update(WordList updatedItem)
        {
            var entity = _appDbContext.WordsList.Attach(updatedItem);
            entity.State = EntityState.Modified;
            return updatedItem;
        }
    }
}

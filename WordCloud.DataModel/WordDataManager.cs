using System.Collections.Generic;
using System.Linq;
using WordCloud.Core;
using WordCloud.DataModel.Models;

namespace WordCloud.DataModel
{
    public class WordDataManager
    {
        private WordContext _context;

        public WordDataManager()
        {
            _context = new WordContext();
        }
      
        public List<WordDM> GetWorldCloudDataFromDB()
        {
            return _context.Words.ToList(); 
        }


        public void AddWordCloudDataToDB(List<Word> wcData)
        {
            
        }

    }
}
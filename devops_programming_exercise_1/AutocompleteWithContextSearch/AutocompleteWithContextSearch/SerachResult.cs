using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutocompleteWithContextSearch {
    public class SerachResult {
        public List<Student> MatchingStudents { get; set; }
        public char MostCommonNextChar { get; set; }
        public int NextCharCount { get; set; }
    }
}

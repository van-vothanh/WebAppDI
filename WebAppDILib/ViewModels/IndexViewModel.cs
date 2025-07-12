using System.Collections.Generic;

namespace CasCap.ViewModels
{
    public class IndexViewModel
    {
        public List<int> SomeIntValues { get; set; } = new();
        public List<string> SomeStringValues { get; set; } = new();
    }
}
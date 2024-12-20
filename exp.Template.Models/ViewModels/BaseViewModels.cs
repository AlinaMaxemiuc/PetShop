using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Models.ViewModels
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PagingViewModel<T>
    {
        public int Count { get; set; }
        public int NumberOfPages { get; set; }
        public List<T> Items { get; set; } = new(new List<T>());
    }
    public class ImageViewModel
    {
        [ImageTypeValidation]
        public string? ImgBase64 { get; set; }
    }
}

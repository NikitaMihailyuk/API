using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_api.BusinessObject.Model
{
    internal class CreateProjectModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Access { get; set; }
        public string Group { get; set; }
    }
}

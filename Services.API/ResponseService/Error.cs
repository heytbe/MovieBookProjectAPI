using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.ResponseService
{
    public class Error
    {
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsShow { get; set; }

        public Error(List<string> error,bool isShow)
        {
            Errors = error;
            IsShow = isShow;
        }

        public Error(string errorMessage,bool isShow)
        {
            Errors.Add(errorMessage);
            IsShow = isShow;
        }

    }
}

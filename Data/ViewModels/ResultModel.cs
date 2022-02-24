using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class ResultModel
    {
        public bool IsSuccess { get; set; }
        public object ResponseSuccess { get; set; }
        public object ResponseFailed { get; set; }
        public int Code { get; set; }
    }
}

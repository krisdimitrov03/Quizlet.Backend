using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Models.Return
{
    public abstract class ReturnModel
    {
        public ReturnModel(bool success)
        {
            this.Success = success;
        }

        public bool Success { get; set; }
    }
}

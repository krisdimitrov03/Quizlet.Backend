﻿using Quizlet.Core.Models;
using Quizlet.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet.Core.Contracts
{
    public interface IQuizService 
        : IEntityService<Quiz, QuizCreateModel, string, QuizEditModel>
    {
    }
}

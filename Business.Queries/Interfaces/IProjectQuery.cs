using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries.Interfaces
{
    public interface IProjectQuery
    {
        IQueryable<Project> Get();
        Project Get(int id);
        Project Create(Project model);
        Project Update(int id, Project model);
        Project Delete(int id);
    }
}

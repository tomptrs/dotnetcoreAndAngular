using Business.Queries.Interfaces;
using Data.Access;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries
{
    public class ProjectQuery : IProjectQuery
    {
        AppDbContext context;
        public ProjectQuery(AppDbContext _context)
        {
            context = _context;
           

        }
        public Project Create(Project model)
        {
            
            var item = context.Projects.Add(model);
            context.SaveChanges();
            
            return item.Entity;
            
        }

        public Project Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Project> Get()
        {
            return context.Projects;
        }

        public Project Get(int id)
        {
            return context.Projects.Where(p => p.Id == id).Single();
        }

        public Project Update(int id, Project model)
        {
            throw new NotImplementedException();
        }
    }
}

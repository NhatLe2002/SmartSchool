using SmartSchool.Models;
using SmartSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.UnitOfWork
{
    public interface IUnitOfWork
    {
        public RepositoryBase<Parent> ParentRepo { get; }
        public RepositoryBase<Recognition> RecognitionRepo { get; }
        public RepositoryBase<Student> StudentRepo { get; }
        public void SaveChanges();
    }
}

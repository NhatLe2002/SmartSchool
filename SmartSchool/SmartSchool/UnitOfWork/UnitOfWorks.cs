using SmartSchool.Models;
using SmartSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly SmartSchoolContext _context;
        public UnitOfWorks(SmartSchoolContext context)
        {
            _context = context;
        }
        private RepositoryBase<Parent> parentRepo;
        public RepositoryBase<Parent> ParentRepo
        {
            get
            {
                if (parentRepo == null)
                {
                    return new RepositoryBase<Parent>(_context);
                }
                return parentRepo;
            }
        }
        private RepositoryBase<Recognition> recognitionRepo;
        public RepositoryBase<Recognition> RecognitionRepo
        {
            get
            {
                if (recognitionRepo == null)
                {
                    return new RepositoryBase<Recognition>(_context);
                }
                return recognitionRepo;
            }
        }
        private RepositoryBase<Student> studentRepo;
        public RepositoryBase<Student> StudentRepo
        {
            get
            {
                if (studentRepo == null)
                {
                    return new RepositoryBase<Student>(_context);
                }
                return studentRepo;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

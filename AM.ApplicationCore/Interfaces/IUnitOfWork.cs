using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Save(); //commit des changement dans db
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
//instancier un repo d une entite donne
    }
}

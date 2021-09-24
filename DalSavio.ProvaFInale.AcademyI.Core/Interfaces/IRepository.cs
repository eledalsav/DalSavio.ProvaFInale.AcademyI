using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSavio.ProvaFInale.AcademyI.Core
{
    public interface IRepository<T>
    {
        void Update(T item);
        List<T> Fetch();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repository
{
    public  interface IRepository 
    {
    
        Task<bool> UpdateAsync();
        Task<bool> DeleteAsync(int Id);
    }
}

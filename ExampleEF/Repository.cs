using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExampleEF
{
    //https://docs.microsoft.com/fr-fr/ef/core/
    public class Repository
    {
        public Task<Eleve> GetFirstUpperTo10()
        {
            using(var context = new EleveContext())
            {
               return context.Set<Eleve>().Where(c => c.Note > 10).OrderByDescending(c => c.Note).FirstOrDefaultAsync();
            }
        }

        public Task Add(Eleve eleve)
        {
            using (var context = new EleveContext())
            {
                context.Set<Eleve>().Add(eleve);
                return context.SaveChangesAsync();
            }
        }
    }
}
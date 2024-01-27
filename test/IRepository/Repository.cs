using Microsoft.EntityFrameworkCore.ChangeTracking;
using test.Models;

namespace test.IRepository
{
    public interface Repository<T> where T:class
    {
        IEnumerable<T> listo();
        T findo(int id);
        T  addo(T my);
        Item edito(Item my,int id);
        void removeo(T my,int id);
    }
}

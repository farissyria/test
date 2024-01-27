using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace test.IRepository
{
    public class ItemRepo<T> : Repository<T> where T : class
    {

        //constructor
        public ItemRepo(Dbcontext _dbcontext )
        {
            dbcontext= _dbcontext;
           
        }
       
        private readonly Dbcontext dbcontext;
        



        public T findo(int id)
        {
           return dbcontext.Set<T>().Find(id);
        }

        public T addo(T my)
        {
          
            dbcontext.Set<T>().Add(my);
            dbcontext.SaveChanges();
            return my;
        }

        //public Item edito(Item my,int id)
        //{

        //    dbcontext.Set<T>().Find(id);

        //    dbcontext.Update(my);
        //    dbcontext.SaveChanges();
        //    return my;
        //}

        public IEnumerable<T> listo()
        {
            return dbcontext.Set<T>().ToList();
        }

        public void removeo(T my,int id)
        {
            dbcontext.Set<T>().Remove(my);
            dbcontext.SaveChanges();
        }

        public Item edito(Item my, int id)
        {
          var it=dbcontext.items.Find(id);
            it.Name=my.Name;
            it.Price=my.Price;
            it.ImagePath=my.ImagePath;
           
            
            
   
            dbcontext.SaveChanges();
            return my;
        }
    }
 
    }
 
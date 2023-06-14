using AracSatis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AracSatis.DesignPatterns.Singleton
{
    public class DBTool
    {
        DBTool() { }
        static AppDbContext _dbInstance;
        public static AppDbContext DbInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                   
                }
                return _dbInstance;
            }
        }
    }
}

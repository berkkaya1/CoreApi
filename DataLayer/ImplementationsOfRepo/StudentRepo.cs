using DataLayer.ContextInfo;
using DataLayer.InterfacesOfRepo;
using EntityLayer.Models;
using Microsoft.IdentityModel.Tokens;

namespace DataLayer.ImplementationsOfRepo;

public class StudentRepo : Repository<Student,int>,IStudentRepo
{
    public StudentRepo(MyContext context) : base(context)
    {
        
    }
}
using AutoMapper;
using EntityLayer.Models;
using EntityLayer.ViewModels;

namespace EntityLayer.Mappings;

public class Maps : Profile
{
    public Maps()
    {
        //StudentVM kullanicinin gordugu kisim student ise
        //databasedeki kisim donusum yapabilmek icin automapper kullaniyoruz
        
        CreateMap<Student, StudentVM>().ReverseMap();
    }
}
using AutoMapper;
using Event.Model.EntityModels;
using Event.Web.Models.ViewModels;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;


namespace Event.Model.Mapper
{
    public  class MappingProfile: Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Ewent, EventViewModel>();
            CreateMap<Ewent[], List<EventViewModel>>();
            
        }

        
    }

}

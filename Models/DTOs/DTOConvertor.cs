using AutoMapper;
using SCnewAppi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCnewAppi.Models.DTOs;

namespace SCnewAppi.Models
{
    public class DTOConvertor
    {
        
        public Func<Course, CourseDTO> courseConvertor = c => ConfigureCourse().Map<CourseDTO>(c);
        public Func<Student, StudentDTO> studentConvertor = s => ConfigureStudent().Map<StudentDTO>(s);

        private static IMapper ConfigureStudent()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.CoursesNames, opt => opt.MapFrom((so => so.Enrollments
                                                                            .Select(t => t.Course)
                                                                            .Select( c => c.Title).ToList())));
            });
           return config.CreateMapper();
        }

        private static IMapper ConfigureCourse()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>()
                .ForMember(dest => dest.StudentsNames, opt => opt.MapFrom((so => so.Enrollments
                                                                            .Select(t => t.Student)
                                                                            .Select(c => c.FirstName).ToList())));
            });
            return config.CreateMapper();
        }
    }
}
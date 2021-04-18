using Application.Mapping;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
	public class UpdateFoodDto : IMap
	{
		public int Id { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateFoodDto, Food>().ReverseMap();
		}
	}
}
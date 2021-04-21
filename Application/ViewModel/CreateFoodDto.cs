﻿using Application.Mapping;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
	public class CreateFoodDto : IMap
	{
		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateFoodDto, Food>().ReverseMap();
		}
	}
}
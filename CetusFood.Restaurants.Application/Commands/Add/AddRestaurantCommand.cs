﻿using CetusFood.Common.Abstractions.Dtos;
using MediatR;

namespace CetusFood.Restaurants.Application.Commands.Add;

public record AddRestaurantCommand(string Name, string Address, string PhoneNumber, short OpenHour, short CloseHour) : IRequest<ObjectCreatedDto>;
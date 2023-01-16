using MediatR;

namespace CetusFood.Restaurants.Application.Commands.Archive;

public record ArchiveRestaurantCommand(Guid Id) : IRequest;
using AutoMapper;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.ReservationDtos;
using CodeAlpha_RestaurantManagementSystem.Business.Helpers.Exceptions;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces;
using CodeAlpha_RestaurantManagementSystem.Core.Entities;
using CodeAlpha_RestaurantManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationGetDto>> GetAllAsync()
        {
            var reservations = await _unitOfWork.Reservations.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationGetDto>>(reservations);
        }

        public async Task<ReservationGetDto> GetByIdAsync(int id)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);
            if (reservation == null)
                throw new NotFoundException($"Reservation with ID {id} was not found.");

            return _mapper.Map<ReservationGetDto>(reservation);
        }

        public async Task CreateAsync(ReservationCreateDto dto)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(dto.TableId);
            if (table == null)
                throw new NotFoundException($"Table with ID {dto.TableId} does not exist.");

            var entity = _mapper.Map<Reservation>(dto);


            await _unitOfWork.Reservations.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);
            if (reservation == null)
                throw new NotFoundException($"Reservation with ID {id} was not found.");

            _unitOfWork.Reservations.Remove(reservation);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

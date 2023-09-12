﻿using AutoMapper;
using Fiorello.Application.Abstraction.Repositories;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.CategoryDtos;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Exceptions;

namespace Fiorello.Persistence.Implementations.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryReadRepository categoryReadRepository,
                           ICategoryWriteRepository categoryWriteRepository,
                           IMapper mapper)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _mapper = mapper;
    }

    async Task ICategoryService.AddAsync(CategoryCreateDto categoryDto)
    {
       Category  categoryDb =await _categoryReadRepository.GetFiltered(c=>c.Name == categoryDto.Name.ToUpper());
        if (categoryDb is not null)
        {
            throw new DuplicatedException("Category Already Exist!");
        }
        Category newCategory = _mapper.Map<Category> (categoryDto);
       await _categoryWriteRepository.AddAsync(newCategory);
       await _categoryWriteRepository.SaveChangeAsync();
    }

   public async Task<CategoryGetDto?>FindAsync(Guid id)
    {
        Category? categoryDb = await _categoryReadRepository.FindAsync(id);
        if (categoryDb is null)
        {
            throw new NotFoundException("Category Not Found!");
        }
        return _mapper.Map<CategoryGetDto?>(categoryDb);
    }

    List<Category> ICategoryService.GetAll()
    {
        throw new NotImplementedException();
    }
}

package org.wonkim.homescheduler.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Async;
import org.springframework.stereotype.Service;
import org.wonkim.homescheduler.data.repository.UserRepository;
import org.wonkim.homescheduler.dto.RequestDto;
import org.wonkim.homescheduler.dto.UpdateResponseDto;
import org.wonkim.homescheduler.dto.UserDto;
import org.wonkim.homescheduler.dto.UserRequestDto;
import org.wonkim.homescheduler.data.entity.User;

import java.time.Instant;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.CompletableFuture;
import java.util.stream.Collectors;

// https://www.baeldung.com/spring-component-repository-service
@Service
public class UserService implements IUserService {
    private final UserRepository _repo;

    @Autowired
    public UserService(UserRepository repo) {
        _repo = repo;
    }

    private User convertToEntity(UserDto dto) {
        if (dto == null) return null;

        User entity = new User();
        entity.setUserId(dto.getUserId());
        entity.setUserName(dto.getUserName());
        entity.setFirstName(dto.getFirstName());
        entity.setLastName(dto.getLastName());
        entity.setCreatedBy(dto.getCreatedBy());
        entity.setCreatedDate(dto.getCreatedDate());
        entity.setUpdatedBy(dto.getUpdatedBy());
        entity.setUpdatedDate(dto.getUpdatedDate());
        return entity;
    }

    private UserDto convertToDto(User entity) {
        if (entity == null) return null;

        UserDto dto = new UserDto();
        dto.setUserId(entity.getUserId());
        dto.setUserName(entity.getUserName());
        dto.setFirstName(entity.getFirstName());
        dto.setLastName(entity.getLastName());
        dto.setCreatedBy(entity.getCreatedBy());
        dto.setCreatedDate(entity.getCreatedDate());
        dto.setUpdatedBy(entity.getUpdatedBy());
        dto.setUpdatedDate(entity.getUpdatedDate());
        return dto;
    }

    private User convertToEntity(UserRequestDto dto) {
        if (dto == null) return null;

        User entity = new User();
        entity.setUserName(dto.getUserName());
        entity.setFirstName(dto.getFirstName());
        entity.setLastName(dto.getLastName());
        return entity;
    }

    @Async
    public CompletableFuture<UserDto> getById(int id) {
        User entity = _repo.findById(id).orElseThrow();
        UserDto dto = convertToDto(entity);
        return CompletableFuture.completedFuture(dto);
    }

    @Async
    public CompletableFuture<List<UserDto>> get() {
        List<User> entityList = _repo.findAll();
        List<UserDto> dtoList = entityList.stream().map(x -> convertToDto(x)).collect(Collectors.toList());
        return CompletableFuture.completedFuture(dtoList);
    }

    public UpdateResponseDto<UserDto> add(RequestDto<UserRequestDto> requestDto) {
        if (requestDto == null) return new UpdateResponseDto<>();

        User entity = convertToEntity(requestDto.getData());
        if (entity == null) return new UpdateResponseDto<>();

        Date nowDate = Date.from(Instant.now());

        entity.setCreatedBy(requestDto.getUpdatedBy());
        entity.setCreatedDate(nowDate);
        entity.setUpdatedBy(requestDto.getUpdatedBy());
        entity.setUpdatedDate(nowDate);

        entity = _repo.save(entity);
        UserDto dto = convertToDto(entity);
        return new UpdateResponseDto<>(dto, 1);
    }

    public UpdateResponseDto<UserDto> update(int id, RequestDto<UserRequestDto> requestDto) {
        Optional<User> optEntity = _repo.findById(id);
        if (optEntity.isEmpty()) return new UpdateResponseDto<>();

        Date nowDate = Date.from(Instant.now());

        User entity = optEntity.get();
        entity.setUserName(requestDto.getData().getUserName());
        entity.setFirstName(requestDto.getData().getFirstName());
        entity.setLastName(requestDto.getData().getLastName());
        entity.setUpdatedBy(requestDto.getUpdatedBy());
        entity.setUpdatedDate(nowDate);

        entity = _repo.save(entity);
        UserDto dto = convertToDto(entity);
        return new UpdateResponseDto<>(dto, 1);
    }
}

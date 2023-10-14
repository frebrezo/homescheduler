package org.wonkim.homescheduler.service;

import org.wonkim.homescheduler.dto.RequestDto;
import org.wonkim.homescheduler.dto.UpdateResponseDto;
import org.wonkim.homescheduler.dto.UserDto;
import org.wonkim.homescheduler.dto.UserRequestDto;

import java.util.List;
import java.util.concurrent.CompletableFuture;

public interface IUserService {
    CompletableFuture<UserDto> getById(int id);
    CompletableFuture<List<UserDto>> get();
    UpdateResponseDto<UserDto> add(RequestDto<UserRequestDto> dto);
    UpdateResponseDto<UserDto> update(int id, RequestDto<UserRequestDto> dto);
}

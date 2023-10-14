package org.wonkim.homescheduler.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.wonkim.homescheduler.dto.*;
import org.wonkim.homescheduler.service.IAvailabilityService;
import org.wonkim.homescheduler.service.IUserService;

import java.util.List;
import java.util.concurrent.CompletableFuture;

@RestController
@CrossOrigin(origins = "http://localhost:8080")
@RequestMapping(path = "/api/user")
public class UserController {
    private final IUserService _service;
    private final IAvailabilityService _availabilityService;

    @Autowired
    public UserController(IUserService userService, IAvailabilityService availabilityService) {
        _service = userService;
        _availabilityService = availabilityService;
    }

    @GetMapping("")
    public GetResponseDto<UserDto> get() throws Exception {
        CompletableFuture<List<UserDto>> future = _service.get();
        List<UserDto> dtoList = future.get();
        GetResponseDto<UserDto> response = new GetResponseDto<>(dtoList);
        return response;
    }

    @GetMapping("/{id}")
    public UserDto getById(@PathVariable("id") int id) throws Exception {
        CompletableFuture<UserDto> future = _service.getById(id);
        UserDto dto = future.get();
        return dto;
    }

    @PutMapping("{id}/availability")
    public ResponseEntity<PostResponseDto<AvailabilityDto>> toggle(@PathVariable("id") int id, @RequestBody NoDataRequestDto request)
    {
        UpdateResponseDto<AvailabilityDto> result = _availabilityService.toggle(id, request);
        if (result.getData() == null) return ResponseEntity.status(422).body(null); //Failed to create User.

        return ResponseEntity.ok().body(new PostResponseDto<AvailabilityDto>(result.getData(), result.getChangeCount()));
    }

    @PostMapping("")
    public UpdateResponseDto<UserDto> add(@RequestBody RequestDto<UserRequestDto> dto) {
        UpdateResponseDto<UserDto> responseDto = _service.add(dto);
        return responseDto;
    }

    @PutMapping("/{id}")
    public UpdateResponseDto<UserDto> update(@PathVariable("id") int id, @RequestBody RequestDto<UserRequestDto> dto) {
        UpdateResponseDto<UserDto> responseDto = _service.update(id, dto);
        return responseDto;
    }
}

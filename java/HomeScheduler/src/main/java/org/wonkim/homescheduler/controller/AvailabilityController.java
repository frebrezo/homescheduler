package org.wonkim.homescheduler.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import org.wonkim.homescheduler.dto.AvailabilityDto;
import org.wonkim.homescheduler.dto.GetResponseDto;
import org.wonkim.homescheduler.service.IAvailabilityService;

import java.util.List;
import java.util.concurrent.CompletableFuture;

@RestController
@CrossOrigin(origins = "http://localhost:8080")
@RequestMapping(path = "/api/availability")
public class AvailabilityController {
    private final IAvailabilityService _service;

    @Autowired
    public AvailabilityController(IAvailabilityService service) {
        _service = service;
    }

    @GetMapping("")
    public GetResponseDto<AvailabilityDto> get() throws Exception {
        List<AvailabilityDto> dtoList = _service.get();
        GetResponseDto<AvailabilityDto> response = new GetResponseDto<>(dtoList);
        return response;
    }

    @GetMapping("/{id}")
    public AvailabilityDto getById(@PathVariable("id") int id) throws Exception {
        AvailabilityDto dto = _service.getById(id);
        return dto;
    }
}

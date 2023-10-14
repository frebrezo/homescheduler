package org.wonkim.homescheduler.service;

import org.wonkim.homescheduler.dto.AvailabilityDto;
import org.wonkim.homescheduler.dto.NoDataRequestDto;
import org.wonkim.homescheduler.dto.UpdateResponseDto;

import java.util.List;

public interface IAvailabilityService {
    AvailabilityDto getById(int id);
    List<AvailabilityDto> get();
    UpdateResponseDto<AvailabilityDto> toggle(int userId, NoDataRequestDto requestDto);
}

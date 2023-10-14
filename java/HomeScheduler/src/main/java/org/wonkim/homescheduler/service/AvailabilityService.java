package org.wonkim.homescheduler.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.wonkim.homescheduler.data.entity.Availability;
import org.wonkim.homescheduler.data.repository.AvailabilityRepository;
import org.wonkim.homescheduler.dto.AvailabilityDto;
import org.wonkim.homescheduler.dto.NoDataRequestDto;
import org.wonkim.homescheduler.dto.UpdateResponseDto;

import java.time.Instant;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class AvailabilityService implements IAvailabilityService {
    private final AvailabilityRepository _repo;

    @Autowired
    public AvailabilityService(AvailabilityRepository repo) {
        _repo = repo;
    }

    private AvailabilityDto convertToDto(Availability entity) {
        if (entity == null) return null;

        AvailabilityDto dto = new AvailabilityDto();
        dto.setAvailabilityId(entity.getAvailabilityId());
        dto.setAvailable(entity.getAvailable());
        dto.setUserId(entity.getUserId());
        dto.setCreatedBy(entity.getCreatedBy());
        dto.setCreatedDate(entity.getCreatedDate());
        dto.setUpdatedBy(entity.getUpdatedBy());
        dto.setUpdatedDate(entity.getUpdatedDate());
        return dto;
    }

    public AvailabilityDto getById(int id) {
        Availability entity = _repo.findById(id).orElseThrow();
        AvailabilityDto dto = convertToDto(entity);
        return dto;
    }

    public List<AvailabilityDto> get() {
        List<Availability> entityList = _repo.findAll();
        List<AvailabilityDto> dtoList = entityList.stream().map(x -> convertToDto(x)).collect(Collectors.toList());
        return dtoList;
    }

    public UpdateResponseDto<AvailabilityDto> toggle(int userId, NoDataRequestDto requestDto)
    {
        Date nowDate = Date.from(Instant.now());

        Availability entity = null;
        Optional<Availability> optEntity = _repo.findByUserId(userId);
        if (optEntity.isPresent())
        {
            entity = optEntity.get();
            entity.setAvailable(!entity.getAvailable());
            entity.setUpdatedBy(requestDto.getUpdatedBy());
            entity.setUpdatedDate(nowDate);
        }
        else
        {
            entity = new Availability();
            entity.setAvailable(false);
            entity.setUserId(userId);
            entity.setCreatedBy(requestDto.getUpdatedBy());
            entity.setCreatedDate(nowDate);
            entity.setUpdatedBy(requestDto.getUpdatedBy());
            entity.setUpdatedDate(nowDate);
        }

        entity = _repo.save(entity);
        AvailabilityDto dto = convertToDto(entity);
        return new UpdateResponseDto(dto, 1);
    }
}

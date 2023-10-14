package org.wonkim.homescheduler.service;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.wonkim.homescheduler.data.entity.Availability;
import org.wonkim.homescheduler.data.repository.AvailabilityRepository;
import org.wonkim.homescheduler.dto.AvailabilityDto;
import org.wonkim.homescheduler.dto.NoDataRequestDto;
import org.wonkim.homescheduler.dto.UpdateResponseDto;

import java.time.Instant;
import java.util.Date;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotEquals;
import static org.mockito.ArgumentMatchers.anyInt;
import static org.mockito.ArgumentMatchers.isA;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class AvailabilityServiceTest {
    private AvailabilityRepository _availabilityRepositoryMock;
    private Availability _entity;
    private AvailabilityDto _dto;

    @BeforeEach
    public void setup() {
        Date nowDate = Date.from(Instant.now());

        _entity = new Availability();
        _entity.setAvailabilityId(1);
        _entity.setAvailable(true);
        _entity.setUserId(1);
        _entity.setCreatedBy("SYSTEM");
        _entity.setCreatedDate(nowDate);
        _entity.setUpdatedBy("SYSTEM");
        _entity.setUpdatedDate(nowDate);

        _dto = new AvailabilityDto();
        _dto.setAvailabilityId(1);
        _dto.setAvailable(true);
        _dto.setUserId(1);
        _dto.setCreatedBy("SYSTEM");
        _dto.setCreatedDate(nowDate);
        _dto.setUpdatedBy("SYSTEM");
        _dto.setUpdatedDate(nowDate);

        _availabilityRepositoryMock = mock(AvailabilityRepository.class);
        when(_availabilityRepositoryMock.save(isA(Availability.class))).thenReturn(_entity);
    }

    @Test
    public void toggleAvailability_ExistingEntity_Test() {
        when(_availabilityRepositoryMock.findByUserId(anyInt())).thenReturn(Optional.ofNullable(_entity));

        IAvailabilityService service = new AvailabilityService(_availabilityRepositoryMock);
        UpdateResponseDto<AvailabilityDto> result = service.toggle(1, new NoDataRequestDto("SYSTEM"));
        assertEquals(_dto.getAvailabilityId(), result.getData().getAvailabilityId());
        assertNotEquals(_dto.getAvailable(), result.getData().getAvailable());
        assertEquals(_dto.getUserId(), result.getData().getUserId());
        assertEquals(_dto.getCreatedBy(), result.getData().getCreatedBy());
        assertEquals(_dto.getUpdatedBy(), result.getData().getUpdatedBy());
    }

    @Test
    public void toggleAvailability_NullEntity_Test() {
        when(_availabilityRepositoryMock.findByUserId(anyInt())).thenReturn(Optional.ofNullable(null));

        IAvailabilityService service = new AvailabilityService(_availabilityRepositoryMock);
        UpdateResponseDto<AvailabilityDto> result = service.toggle(1, new NoDataRequestDto("SYSTEM"));
        assertEquals(_dto.getAvailabilityId(), result.getData().getAvailabilityId());
        assertEquals(_dto.getAvailable(), result.getData().getAvailable());
        assertEquals(_dto.getUserId(), result.getData().getUserId());
        assertEquals(_dto.getCreatedBy(), result.getData().getCreatedBy());
        assertEquals(_dto.getUpdatedBy(), result.getData().getUpdatedBy());
    }
}
